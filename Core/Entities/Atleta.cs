﻿using System.ComponentModel.DataAnnotations.Schema;

namespace team_manegement_api.Core
{
    public class Atleta : BaseModel
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public string Dominancia { get; set; }  
        public string Posicao { get; set; }
        [NotMapped]
        public int? Minutagem { get; set; }
        [NotMapped]
        public int? Gols { get; set; }
        [NotMapped]
        public int? Assistencias { get; set; }
        [NotMapped]
        public int? CartoesAmarelos { get; set; }
        [NotMapped]
        public int? CartoesVermelhos { get; set; }

        [NotMapped]
        public List<ExameMedico>? ExamesMedicos { get; set;}
        [NotMapped]
        public List<Nota>? Notas { get; set; }

    }
}
