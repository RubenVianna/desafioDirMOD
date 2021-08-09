using System;
using System.Text;

namespace teclado
{
    class Program
    {
        static void Main(string[] args)
        {
            int correcto = 5;
            string mensaje = "";
            string cadenaADevolver = "";
            string Output = null;
            string[,] abc = new string[26, 2];
            char valorViejo = ' ';

            while (correcto != 1) //Validamos que el usuario ingreso lo que quiere buscar, caso contrario se vuelve a pedir que ingrese los datos si asi lo desea
            {
                Console.WriteLine("Ingrese el mensaje que desea escribir (Sin letra ñ ni numeros ni caracteres especiales): ");
                mensaje = Console.ReadLine();
                Console.WriteLine("Usted escribio el siguiente mensaje: " + mensaje);
                Console.WriteLine("¿Es correcto? 1- SI  2- NO");
                correcto = int.Parse(Console.ReadLine());
                mensaje = mensaje.ToUpper();

                if (correcto != 1 && correcto != 2)
                {
                    Console.WriteLine("Usted ingreso una opcion no valida, por favor, intente de nuevo");
                }
            }

            int cantidadLetras = mensaje.Length;
            CargarMatriz();


            for (int i = 0; i < cantidadLetras; i++) //Se recorre el string letra por letra para realizar la busqueda del valor de cada una con la funcion CalcularOutput
            {
                char letraABuscar = mensaje[i];
                string valorNuevo = CalcularOutput(letraABuscar);

                if (valorNuevo.StartsWith(valorViejo))
                {
                    cadenaADevolver = cadenaADevolver + " " + valorNuevo;
                }
                else
                {
                    cadenaADevolver = cadenaADevolver + valorNuevo;
                }
                valorViejo = valorNuevo[0];
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("El valor pasado a codigo de celular es: " + cadenaADevolver);
            Console.WriteLine("-------------------------------------------");

            void CargarMatriz()  //Se carga la matriz con las letras del abecedario, menos la Ñ, y se le asigna el valor que le correspondera en un teclado de celular
            {
                for (int i = 0; i < 26; i++)
                {
                    char letraACargar = Convert.ToChar(i + 65);
                    string letraMatriz = letraACargar.ToString();
                    abc[i, 0] = letraMatriz;
                    //     Console.WriteLine(abc[i, 0]);
                }

                string valorMatriz = null;
                int contador = 2;
                int reset = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (contador < 10)
                    {
                        if (contador != 7 && contador != 9)
                        {
                            valorMatriz = valorMatriz + contador.ToString();
                            abc[i, 1] = valorMatriz;
                            reset++;

                            if (reset == 3)
                            {
                                contador++;
                                reset = 0;
                                valorMatriz = null;
                            }
                        }
                        else
                        {
                            valorMatriz = valorMatriz + contador.ToString();
                            abc[i, 1] = valorMatriz;
                            reset++;

                            if (reset == 4)
                            {
                                contador++;
                                reset = 0;
                                valorMatriz = null;
                            }
                        }
                    }
               //     Console.WriteLine(abc[i, 1]);
                }
            }

            string CalcularOutput(char letraABuscar)  //Recorre la matriz de letras y nos devuelve su valor en formato celular
            {
                for (int i = 0; i < 26; i++)
                {
                    char letraABC = char.Parse(abc[i, 0]);

                    if (letraABuscar == letraABC)
                    {
                        Output = abc[i, 1];

                    }
                    else if (letraABuscar == ' ')
                    {
                        Output = "0";
                    }
                }

                return Output;
            }
        }

    }
}

