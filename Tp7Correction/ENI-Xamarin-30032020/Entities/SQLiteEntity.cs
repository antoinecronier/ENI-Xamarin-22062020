using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ENI_Xamarin_30032020.Entities
{
    public class SQLiteEntity
    {
        private long? id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
