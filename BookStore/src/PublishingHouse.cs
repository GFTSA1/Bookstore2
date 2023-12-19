using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore
{
    public class PublishingHouse // видавництво
    {
        [Key]
        public int Id {  get; set; }

        private String _name;
        private String _country;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public String Сountry
        {
            get
            {
                return _country;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("Ви не країну видавництва.");
                else _country = value;
            }
        }


        public virtual List<Edition> Editions { get; set; } = new List<Edition>();
       public PublishingHouse()
       { 
        
       }
        public PublishingHouse(String name, String country)
        {
            this.Name = name;
            this.Сountry = country;
        }
    }
}
