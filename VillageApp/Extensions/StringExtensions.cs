using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageApp.Extensions
{
    public static class StringExtensions
    {
        public static string AsTimeAgo(this DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);

            return timeSpan.TotalSeconds switch
            {
                <= 60 => $"{timeSpan.Seconds} segundos atrás",

                _ => timeSpan.TotalMinutes switch
                {
                    <= 1 => "cerca de um minuto atrás",
                    < 60 => $"cerca de {timeSpan.Minutes} minutos atrás",
                    _ => timeSpan.TotalHours switch
                    {
                        <= 1 => "cerca de uma hora atrás",
                        < 24 => $"cerca de {timeSpan.Hours} horas atrás",
                        _ => timeSpan.TotalDays switch
                        {
                            <= 1 => "ontem",
                            <= 30 => $"cerca de {timeSpan.Days} dias atrás",

                            <= 60 => "cerca de um mês atrás",
                            < 365 => $"cerca de {timeSpan.Days / 30} meses atrás",

                            <= 365 * 2 => "cerca de um ano atrás",
                            _ => $"cerca de {timeSpan.Days / 365} anos atrás"
                        }
                    }
                }
            };
        }
    }
}
