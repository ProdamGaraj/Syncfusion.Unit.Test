using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int TemperatureC { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Summary { get; set; }
    }
}
