using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace DataMorphApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarOpciones();
        }

        private void CargarOpciones()
        {
            var opciones = new Dictionary<int, string>
            {
                { 1, "Limpiar datos unicode" },
                { 2, "Transformar Config de acceso" }
            };

            cboSelectAction.DataSource = new BindingSource(opciones, null);
            cboSelectAction.DisplayMember = "Value";
            cboSelectAction.ValueMember = "Key";

            // Establecer la opción predeterminada al iniciar
            cboSelectAction.SelectedIndex = 0;
        }
        private void cboSelectAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectAction.SelectedValue != null)
            {
                txtRequestData.Text = "";
                txtResponseData.Text = "";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResponseData.Text))
            {
                Clipboard.SetText(txtResponseData.Text); // Copia el texto al portapapeles
                MessageBox.Show("Texto copiado al portapapeles.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay texto para copiar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string inputText = txtRequestData.Text;
            int value = (int)cboSelectAction.SelectedValue;

            if (value == 0) {
                MessageBox.Show("Por favor, seleccione una opción válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!String.IsNullOrWhiteSpace(inputText))
            {
                try
                {
                    if (value == 1)
                    {
                        string cleanText = CleanSpecialCharacters(inputText);
                        txtResponseData.Text = cleanText;
                    }
                    else if (value == 2)
                    {
                        string goodConfig = convertirBadConfigToNew(inputText);
                        txtResponseData.Text = goodConfig;
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha sucedido un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            } else
            {
                MessageBox.Show("No hay datos a transformar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            
        }

        private string convertirBadConfigToNew(string inputText)
        {
            try
            {
                // Deserializar la configuración de entrada
                var jsonObject = JsonNode.Parse(inputText);

                // Crear un nuevo objeto para la estructura deseada
                var output = new Dictionary<string, object>
                {
                    { "code", 0 },
                    { "user", jsonObject["accessConfiguration"]?["user"]?.ToString() ?? string.Empty },
                    { "password", jsonObject["accessConfiguration"]?["password"]?.ToString() ?? string.Empty },
                    { "urls", new Dictionary<string, string>
                        {
                            { "generic", jsonObject["accessConfiguration"]?["urls"]?["generic"]?.ToString() ?? string.Empty }
                        }
                    }
                };

                // Crear el diccionario de parámetros
                var parameters = new Dictionary<string, string>();
                foreach (var param in jsonObject["accessConfiguration"]["parameters"].AsArray())
                {
                    string key = param["key"].ToString();
                    string value = param["value"].ToString();
                    parameters.Add(key, value);
                }
                output.Add("parameters", parameters);

                // Serializar el resultado a JSON con formato indentado
                var options = new JsonSerializerOptions { WriteIndented = true };
                return JsonSerializer.Serialize(output, options);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


        private string CleanSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string output = Regex.Replace(input, @"\\u([0-9A-Fa-f]{4})", match =>
            {
                // Convertir el valor hexadecimal a un carácter
                int unicodeValue = Convert.ToInt32(match.Groups[1].Value, 16);
                return ((char)unicodeValue).ToString();
            });

            output = output.Replace(@"\u003c", "<")
                            .Replace(@"\u003e", ">")
                            .Replace(@"\""", "\"")
                            .Replace(@"\r", "")
                            .Replace(@"\n", "\n")
                            .Replace("&lt;", "<")
                            .Replace("&gt;", ">")
                            .Replace("&amp;", "&")
                            .Replace("&quot;", "\"")
                            .Replace("&#39;", "'")
                            .Replace("\r", "");

            return output.Trim();
        }
    }
}
