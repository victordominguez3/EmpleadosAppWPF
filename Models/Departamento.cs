using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NavegacionLateralWPF.Models
{
    public class Departamento
    {
        private string id;
        private string name;

        public Departamento(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return name;
        }
    }
}
