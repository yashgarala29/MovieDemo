using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieDemo
{
    [DataContract]
    public class Movies_classcs
    {
        private int id;
        private DateTime releaseDate;
        private string name;
        private string genre;
        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string Genre { get => genre; set => genre = value; }
    }
}
