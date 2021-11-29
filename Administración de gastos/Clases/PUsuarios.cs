using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;

namespace Administración_de_gastos.Clases
{
   static class PUsuarios
    {
        #region Atributos

        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        
        #endregion


        #region CRUD

        public static bool Create(Usuario obj) {

            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "INSERT INTO users (username, password) VALUES (@nombre, @contraseña)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.UserName));
                cmd.Parameters.Add(new SQLiteParameter("@contraseña", obj.Password));

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }

            }
            return respuesta;
        }

        public static Usuario FindUser(string username)
        {

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "SELECT * FROM users WHERE username= @user";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@user", username));

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int id = int.Parse(dr["id"].ToString());
                        string user = dr["username"].ToString();
                        string contra = dr["password"].ToString();
                        string nombre = dr["username"].ToString();
                        string apellido = dr["password"].ToString();

                        Usuario user = new Usuario() {Id=id, Nombre=nombre, contra};
                        user.Id = id;
                        return user;
                    }
                    else{
                        return null;
                    }
                }
            }
        }

        public static List<Usuario> Read2List()
        {

            List<Usuario> lista = new List<Usuario>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "SELECT * FROM users";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = int.Parse(dr["id"].ToString());
                        string nombre = dr["username"].ToString();
                        string contra = dr["password"].ToString();

                        Usuario user = new Usuario(nombre, contra);
                        user.Id = id;
                        lista.Add(user);
                    }
                }
                return lista;
            }
        }

        

        public static bool Update(Usuario obj)
        {

            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "UPDATE users SET username= @nombre, password= @contraseña WHERE id= @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.UserName));
                cmd.Parameters.Add(new SQLiteParameter("@contraseña", obj.Password));

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }

            }
            return respuesta;
        }

        public static bool Delete(Usuario obj)
        {

            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();

                string query = "DELETE FROM users WHERE id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.Id));

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }

            }
            return respuesta;
        }
        #endregion

    }
}
