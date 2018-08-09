using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fluent_NHibernate_Crud_Basico.Models
{
    public class JogoMap : ClassMap<Jogo>
    {
        public JogoMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.Classificacao);
            Table("Jogo");
        }
    }
}