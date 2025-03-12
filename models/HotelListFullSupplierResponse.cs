using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataMorphApp.models
{
    [DataContract]
    public class HotelListFullSupplierResponse
    {
        public IEnumerable<HotelOTV> Hotels;
    }

    [DataContract]
    public class HotelOTV
    {
        [DataMember(Name = "address")]
        public string Address;

        [DataMember(Name = "amenity_groups")]
        public List<AmenityGroup> amenity_groups;

        [DataMember(Name = "check_in_time")]
        public TimeSpan Check_in_time;

        [DataMember(Name = "check_out_time")]
        public TimeSpan check_out_time;

        [DataMember(Name = "description_struct")]
        public List<DescriptionItem> Description_struct;

        [DataMember(Name = "email")]
        public string Email;

        [DataMember(Name = "facts")]
        public Facts facts;

        [DataMember(Name = "id")]
        public string Id;

        [DataMember(Name = "hid")]
        public int Hid;

        [DataMember(Name = "images")]
        public List<string> images;

        [DataMember(Name = "kind")]
        public string kind;

        [DataMember(Name = "latitude")]
        public double Latitude;

        [DataMember(Name = "longitude")]
        public double Longitude;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "hotel_chain")]
        public string Hotel_chain;

        [DataMember(Name = "phone")]
        public string Phone;

        [DataMember(Name = "metapolicy_struct")]
        public MetapolicyStructInfo metapolicy_struct;

        [DataMember(Name = "metapolicy_extra_info")]
        public string metapolicy_extra_info;

        [DataMember(Name = "postal_code")]
        public string postal_code;

        [DataMember(Name = "region")]
        public Region region;

        [DataMember(Name = "room_groups")]
        public List<RoomGroup> room_groups;

        [DataMember(Name = "semantic_version")]
        public string semantic_version;

        [DataMember(Name = "star_rating")]
        public string Star_rating;

        [DataMember(Name = "payment_methods")]
        public List<string> Payment_methods;




        [DataContract]
        public class PolicyItem
        {
            [DataMember(Name = "title")]
            public string title;

            [DataMember(Name = "paragraphs")]
            public List<string> paragraphs;
        }

        [DataContract]
        public class AmenityGroup
        {
            [DataMember(Name = "group_name")]
            public string group_name;
            [DataMember(Name = "amenities")]
            public List<string> amenities;
        }

        [DataContract]
        public class Facts
        {
            [DataMember(Name = "floors_number")]
            public string floors_number;
            [DataMember(Name = "rooms_number")]
            public string rooms_number;
            [DataMember(Name = "year_built")]
            public string year_built;
            [DataMember(Name = "year_renovated")]
            public string year_renovated;
            [DataMember(Name = "electricity")]
            public FactsElectricity electricity;

        }

        [DataContract]
        public class FactsElectricity
        {

            [DataMember(Name = "frequency")]
            public List<string> frequency;
            [DataMember(Name = "voltage")]
            public List<string> voltage;
            [DataMember(Name = "sockets")]
            public List<string> sockets;

        }

        [DataContract]
        public class Region
        {
            [DataMember(Name = "country_code")]
            public string Country_code;
            [DataMember(Name = "country_name")]
            public Dictionary<string, string> country_name;

            [DataMember(Name = "iata")]
            public string iata;

            [DataMember(Name = "id")]
            public string Id;

            [DataMember(Name = "name")]
            public string Name;

            [DataMember(Name = "type")]
            public string Type;
        }

        [DataContract]
        public class RoomGroup
        {
            [DataMember(Name = "name")]
            public string name;

            [DataMember(Name = "images")]
            public List<string> images;

            [DataMember(Name = "room_amenities")]
            public List<string> room_amenities;

            [DataMember(Name = "room_group_id")]
            public string room_group_id;

            [DataMember(Name = "rg_ext")]
            public RoomGroupExt rg_ext;
        }

        [DataContract]
        public class RoomGroupExt
        {
            [JsonProperty(PropertyName = "class")]
            public int class_rg;
            [DataMember(Name = "quality")]
            public int quality;
            [DataMember(Name = "sex")]
            public int sex;
            [DataMember(Name = "bathroom")]
            public int bathroom;
            [DataMember(Name = "bedding")]
            public int bedding;
            [DataMember(Name = "family")]
            public int family;
            [DataMember(Name = "capacity")]
            public int capacity;
            [DataMember(Name = "club")]
            public int club;
            [DataMember(Name = "bedrooms")]
            public int bedrooms;
            [DataMember(Name = "balcony")]
            public int balcony;
            [DataMember(Name = "view")]
            public int view;
            [DataMember(Name = "floor")]
            public int floor;
        }

        [DataContract]
        public class DescriptionItem
        {
            [DataMember(Name = "title")]
            public string title;

            [DataMember(Name = "paragraphs")]
            public List<string> paragraphs;
        }

        [DataContract]
        public class MetapolicyStructInfo
        {
            [DataMember(Name = "add_fee")]
            public List<MetapolicyAddFeeInfo> add_fee;
            [DataMember(Name = "check_in_check_out")]
            public List<MetapolicyCheckInCheckOut> check_in_check_out;
            [DataMember(Name = "children")]
            public List<MetapolicyChildrenInfo> children;
            [DataMember(Name = "children_meal")]
            public List<MetapolicyChildrenMealInfo> children_meal;
            [DataMember(Name = "cot")]
            public List<MetapolicyCotInfo> cot;
            [DataMember(Name = "deposit")]
            public List<MetapolicyDepositInfo> deposit;
            [DataMember(Name = "extra_bed")]
            public List<MetapolicyExtraBedInfo> extra_bed;
            [DataMember(Name = "internet")]
            public List<MetapolicyInternetInfo> internet;
            [DataMember(Name = "meal")]
            public List<MetapolicyMealInfo> meal;
            [DataMember(Name = "no_show")]
            public MetapolicyNoShowInfo no_show;
            [DataMember(Name = "parking")]
            public List<MetapolicyParkingInfo> parking;
            [DataMember(Name = "pets")]
            public List<MetapolicyPetsInfo> pets;
            [DataMember(Name = "shuttle")]
            public List<MetapolicyShuttleInfo> shuttle;
            [DataMember(Name = "visa")]
            public MetapolicyVisaInfo visa;

        }

        public class MetapolicyAddFeeInfo
        {
            [DataMember(Name = "currency")]
            public string currency;
            [DataMember(Name = "fee_type")]
            public string Fee_type;
            [DataMember(Name = "price")]
            public double price;
            [DataMember(Name = "price_unit")]
            public string price_unit;
        }

        public class MetapolicyCheckInCheckOut
        {
            [DataMember(Name = "check_in_check_out_type")]
            public string check_in_check_out_type;
            [DataMember(Name = "currency")]
            public string currency;
            [DataMember(Name = "inclusion")]
            public string inclusion;
            [DataMember(Name = "price")]
            public string price;
        }

        public class MetapolicyChildrenInfo
        {
            [DataMember(Name = "age_end")]
            public string age_end;
            [DataMember(Name = "age_start")]
            public string age_start;
            [DataMember(Name = "currency")]
            public string currency;
            [DataMember(Name = "extra_bed")]
            public string extra_bed;
            [DataMember(Name = "price")]
            public string price;
        }
        public class MetapolicyVisaInfo
        {
            [DataMember(Name = "visa_support")]
            public string visa_support;
        }

        public class MetapolicyShuttleInfo : MetaPolicyBaseCurInc
        {
            [DataMember(Name = "destination_type")]
            public string destination_type;
            [DataMember(Name = "shuttle_type")]
            public string shuttle_type;
        }

        public class MetapolicyPetsInfo : MetaPolicyBaseCurInc
        {
            [DataMember(Name = "pets_type")]
            public string pets_type;
            [DataMember(Name = "price_unit")]
            public string price_unit;
        }

        public class MetapolicyParkingInfo : MetaPolicyBaseCurInc
        {
            [DataMember(Name = "territory_type")]
            public string territory_type;
            [DataMember(Name = "price_unit")]
            public string price_unit;
        }

        public class MetapolicyNoShowInfo
        {
            [DataMember(Name = "availability")]
            public string availability;
            [DataMember(Name = "day_period")]
            public string day_period;
            [DataMember(Name = "time")]
            public string time;
        }

        public class MetapolicyMealInfo : MetaPolicyBaseCurInc
        {
            [DataMember(Name = "meal_type")]
            public string meal_type;
        }

        public class MetapolicyInternetInfo : MetaPolicyBaseCurInc
        {
            [DataMember(Name = "internet_type")]
            public string internet_type;
            [DataMember(Name = "price_unit")]
            public string price_unit;
            [DataMember(Name = "work_area")]
            public string work_area;
        }

        public class MetapolicyExtraBedInfo : MetapolicyCotInfo
        {
        }
        public class MetapolicyDepositInfo
        {
            [DataMember(Name = "availability")]
            public string availability;
            [DataMember(Name = "currency")]
            public string currency;
            [DataMember(Name = "deposit_type")]
            public string deposit_type;
            [DataMember(Name = "price")]
            public string price;
            [DataMember(Name = "price_unit")]
            public string price_unit;
            [DataMember(Name = "payment_type")]
            public string payment_type;
            [DataMember(Name = "pricing_method")]
            public string pricing_method;
        }

        public class MetapolicyCotInfo : MetaPolicyBaseCurInc
        {
            [DataMember(Name = "amount")]
            public string amount;
            [DataMember(Name = "price_unit")]
            public string price_unit;
        }

        public class MetapolicyChildrenMealInfo : MetaPolicyBaseCurInc
        {
            [DataMember(Name = "age_end")]
            public string age_end;
            [DataMember(Name = "age_start")]
            public string age_start;
            [DataMember(Name = "meal_type")]
            public string meal_type;
        }

        public class MetaPolicyBaseCurInc
        {
            [DataMember(Name = "currency")]
            public string currency;
            [DataMember(Name = "inclusion")]
            public string inclusion;
            [DataMember(Name = "price")]
            public string price;
        }

    }
}