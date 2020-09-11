using System;
using System.Collections.Generic;
using System.Text;

namespace POO3C24_14
{
    class BLL_24_14
    {
        private DAL_24_14Mysql DaoBanco = new DAL_24_14Mysql();
        public Boolean Autenticar(int idmusica, string nome, string nomeautor, int idgravadora, int idCd)
        {
            string consulta = string.Format($@"select * from tbl_musica where idmusica = '{idmusica}' and nome = '{nome}' and nomeAutor = '{nomeautor}' and idGravadora = '{idgravadora}' and idCD = '{idCd}' ;");
            DataTable dt = DaoBanco.executarConsulta(consulta);

            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataTable ListarMusicas()
        {
            string sql = string.Format($@"select * from tbl_musica;");
            return DaoBanco.executarConsulta(sql);
        }



        public void AdicionarMusica(DTO_24_14 objMusica)
        {
            DTO_24_14 musica = new DTO_24_14();
            string sql = string.Format($@"insert into tbl_musica values (null, '{objMusica.Nome}', 
                                                                                '{objMusica.NomeAutor}',
                                                                                '{objMusica.Idgravadora}',
                                                                                '{objMusica.IdCD}'); ");
            DaoBanco.executarComando(sql);

        }

        public void ExcluirMusica(DTO_24_14 objMusica)
        {
            string sql = string.Format($@"delete from tbl_musica where idMusica = '{objMusica.Idmusica}';");
            DaoBanco.executarComando(sql);
        }

        public void AlterarMusica(DTO_24_14 objdto)
        {
            string sql = string.Format($@"UPDATE tbl_musica set nome = '{objdto.Nome}',
                                                                nomeAutor = '{objdto.NomeAutor}',
                                                                idGravadora = '{objdto.Idgravadora}',
                                                                idCD = '{objdto.IdCD}'
                                        where idMusica = '{objdto.Idmusica}';");
            DaoBanco.executarComando(sql);
        }
    }
}

