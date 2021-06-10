using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.Tontapat.Model
{
    class Evaluation
    {
        public int Id { get; set; }
        public int IdPrestationEvaluee { get; set; }
        public int IdUtilisateurEvaluee { get; set; }
        public int NoteEvaluation { get; set; }
        public string CommentaireEvaluation { get; set; }

        public Evaluation()
        {
        }
    }
}
