using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApp.Model
{
    class UserEducationList
    {
        public int Id { get; set; }      
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("EducationObject")]
        public int EducationObjectId { get; set; }
        public int Result { get; set; }
        public DateTime Start { get; set; }
    }
}
