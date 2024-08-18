using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Entities
{
    public class VillaNumber
    {
        //duke e bere .None i thote db qe mos ta gjeneroje automatikisht si nje identity per shkak se kemi nje PK dhe nje FK
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] //ben kete entry si primary key, heret e tjera nese ka vec ID te shkruar e kupton vete dhe e ben pk te tabela por ne kete rast nuk ka dhe duhet tja speicfikoj vete
        public int Villa_Number { get; set; }

        [ForeignKey("Villa")]
        public int VillaId { get; set; }
        public Villa Villa { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
