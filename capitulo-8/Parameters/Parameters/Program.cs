#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Parameters
{
    class Program
    {
        static void Entrance()
        {
			int teste = 76;
			Console.WriteLine("Teste: " + Sexo.Masculino);
        }

        static void Main(string[] args)
        {
            try
            {
                Entrance();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

	enum Sexo : short { Masculino, Feminino }
}
