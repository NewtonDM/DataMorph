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
                { 2, "Transformar Config de acceso" },
                { 3, "Método para transformar Objeto a XML" },
                { 4, "Método para transformar Objeto a JSON" },
                { 5, "JENKINS INSTALACIONES" },
                { 6, "EJEMPLOS JIRAS" }
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

                int value = (int)cboSelectAction?.SelectedIndex;
                if (value == 2)
                {
                    txtRequestData.Text = " //.NET\r\n\r\npublic static string ConvertToXml<T>(T obj)\r\n    {\r\n        if (obj == null) \r\n            throw new ArgumentNullException(nameof(obj), \"El objeto no puede ser nulo.\");\r\n\r\n        try\r\n        {\r\n            var xmlSerializer = new XmlSerializer(typeof(T));\r\n            using (var stringWriter = new StringWriter())\r\n            {\r\n                xmlSerializer.Serialize(stringWriter, obj);\r\n                return stringWriter.ToString();\r\n            }\r\n        }\r\n        catch (Exception ex)\r\n        {\r\n            throw new InvalidOperationException(\"Error al convertir el objeto a XML.\", ex);\r\n        }\r\n    }";
                    txtResponseData.Text = "//VB \r\n\r\n Public Shared Function ConvertToXml(Of T)(obj As T) As String\r\n    If obj Is Nothing Then\r\n        Throw New ArgumentNullException(NameOf(obj), \"El objeto no puede ser nulo.\")\r\n    End If\r\n\r\n    Try\r\n        Dim xmlSerializer As New XmlSerializer(GetType(T))\r\n        Using stringWriter As New StringWriter()\r\n            xmlSerializer.Serialize(stringWriter, obj)\r\n            Return stringWriter.ToString()\r\n        End Using\r\n    Catch ex As Exception\r\n        Throw New InvalidOperationException(\"Error al convertir el objeto a XML.\", ex)\r\n    End Try\r\nEnd Function";
                }
                else if (value == 3)
                {

                    txtRequestData.Text = " \r\npublic static string ConvertToJson<T>(T obj)\r\n{{\r\n    if (obj == null)\r\n        throw new ArgumentNullException(nameof(obj), \"El objeto no puede ser nulo.\");\r\n\r\n    try\r\n    {{\r\n        // Serializar el objeto a JSON\r\n        return JsonSerializer.Serialize(obj);\r\n    }}\r\n    catch (Exception ex)\r\n    {{\r\n        throw new InvalidOperationException(\"Error al convertir el objeto a JSON.\", ex);\r\n    }}\r\n}}";
                    txtResponseData.Text = " no hay";
                }
                else if (value == 4)
                {
                    txtRequestData.Text = "Jenkins - jobs instalaciones : Connectors\r\nhttps://jenkins-ci.xmltravelgate.com/job/connectors-pull-hotel/job/shopping/\r\n\r\nJenkins - jobs instalaciones : Legacy\r\nhttps://jenkins-ci.xmltravelgate.com/job/Integrations/job/IntegrationsPullHotel/job/install/job/NSM/\r\n";
                }
                else if (value == 5)
                {
                    txtRequestData.Text = "- Ejemplo Triajes: \r\n• https://travelgatex.atlassian.net/browse/CONN-132?focusedCommentId=417065\r\nhttps://travelgatex.atlassian.net/browse/CONN-136?focusedCommentId=419693 \r\n\r\n ejemplo ticket install fuera de horario;\r\n https://travelgatex.atlassian.net/browse/IHAL-99\r\n\r\n Ticket proactive EXAMPLE\r\nhttps://travelgatex.atlassian.net/browse/ITRMA-87 \r\n\r\n Crear Tickets para Giros: \r\n https://travelgatex.atlassian.net/jira/software/c/projects/ENGDEMAND/boards/284\r\nhttps://travelgatex.atlassian.net/browse/ENGDEMAND-9185 -- giro ejemplo \r\nTicket giro Ejemplo: \r\n https://travelgatex.atlassian.net/browse/ENGDEMAND-8976 \r\n\r\n IPS WHITE LIST\r\nhttps://docs.travelgate.com/kb/getting-started-with-travelgate/About-our-Connectivity/how-do-tgx-ips-work-with-sellers/\r\n\r\nAgregar ProxyById:\r\nhttps://github.com/Travelgate/supply-pull-connectors-integrations-charts \r\n\r\n RCA - PROCEDIMIENTO A SEGUIR: https://travelgatex.atlassian.net/wiki/spaces/TGX/pages/2644213766/Root+Cause+Analysis+RCA";
                }
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
            int value = (int)cboSelectAction?.SelectedIndex;

            if (value == -1) {
                MessageBox.Show("Por favor, seleccione una opción válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!String.IsNullOrWhiteSpace(inputText))
            {
                try
                {
                    if (value == 0)
                    {
                        string cleanText = CleanSpecialCharacters(inputText);
                        txtResponseData.Text = cleanText;
                    }
                    else if (value == 1)
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
