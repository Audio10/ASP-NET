using System;

namespace ASP_NET.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
        
        }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}