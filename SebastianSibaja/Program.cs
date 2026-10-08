using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SebastianSibaja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Byte n = 4 + 10;
            Byte[] posicion_paciente = new byte[n];
            String[] nombre_paciente = new string[n];
            String[] cedula_paciente = new string[n];
            String[] consulta_paciente = new string[n];
            String[] gravedad_paciente = new string[n];
            MostrarMenu(posicion_paciente, nombre_paciente, cedula_paciente, consulta_paciente, gravedad_paciente);
        }

        static void MostrarMenu(Byte[] posicion_paciente, String[] nombre_paciente, String[] cedula_paciente, String[] consulta_paciente, String[] gravedad_paciente)
        {
            byte n = 4 + 10;

            for (byte numero = 0; numero < n; numero++)
            {
                string respuesta = String.Empty;
                bool error = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Agregar paciente");
                Console.WriteLine("2. Buscar pacientes");
                Console.WriteLine("3. Modificar paciente");
                Console.WriteLine("4. Eliminar paciente");
                Console.WriteLine("5. Mostrar lista de pacientes");
                do
                {
                    Console.WriteLine("Que opción desea realizar?: ");
                    Console.ResetColor();
                    respuesta = Console.ReadLine();
                    error = false;
                    switch (respuesta)
                    {
                        case "1":
                            AgregarPaciente(posicion_paciente, nombre_paciente, cedula_paciente, consulta_paciente, gravedad_paciente, n);
                            break;
                        case "2":
                            BuscarPacientes(posicion_paciente, nombre_paciente, cedula_paciente, consulta_paciente, gravedad_paciente, n);
                            break;
                        case "3":
                            ModificarPaciente(posicion_paciente, nombre_paciente, cedula_paciente, consulta_paciente, gravedad_paciente, n);
                            break;
                        case "4":
                            EliminarPaciente(posicion_paciente, nombre_paciente, cedula_paciente, consulta_paciente, gravedad_paciente, n);
                            break;
                        case "5":
                            MostrarLista(posicion_paciente, nombre_paciente, cedula_paciente, consulta_paciente, gravedad_paciente, n);
                            break;
                        default:
                            Console.WriteLine("Opción inválida");
                            Console.WriteLine("Intenta nuevamente...\n");
                            respuesta = Console.ReadLine();
                            error = true;
                            break;
                    }
                } while (error == true);
            }
            Console.WriteLine("-------Fin del programa-------");
        }

        static void AgregarPaciente(Byte[] posicion_paciente, String[] nombre_paciente, String[] cédula_paciente, String[] consulta_paciente, String[] gravedad_paciente, Byte n)
        {
            Console.WriteLine("\n---Agreguemos un paciente---\n");

            int index = -1;
            for (int i = 0; i < n; i++)
            {
                if (cédula_paciente[i] == null)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("No hay espacio para más pacientes.");
                return;
            }

            string nombre = "";
            do
            {
                Console.WriteLine("Ingrese el nombre del paciente: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(nombre));

            string cedula = "";
            bool cedulaUnica = false;
            do
            {
                Console.WriteLine("Ingrese la cédula del paciente: ");
                cedula = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(cedula))
                {
                    Console.WriteLine("La cédula no puede estar vacía.");
                    continue;
                }

                bool encontrada = false;
                for (int i = 0; i < cédula_paciente.Length; i++)
                {
                    if (cédula_paciente[i] == cedula)
                    {
                        encontrada = true;
                        break;
                    }
                }

                if (encontrada)
                {
                    Console.WriteLine("La cédula ya está registrada. Ingrese una cédula distinta.");
                }
                else
                {
                    cedulaUnica = true;
                }
            } while (!cedulaUnica);

            string consulta = "";
            do
            {
                Console.WriteLine("Ingrese la consulta del paciente: ");
                consulta = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(consulta))
                {
                    Console.WriteLine("La consulta no puede estar vacía.");
                }
            } while (string.IsNullOrWhiteSpace(consulta));

            string gravedad = "";
            do
            {
                Console.WriteLine("Ingrese la gravedad del paciente: ");
                gravedad = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gravedad))
                {
                    Console.WriteLine("La gravedad no puede estar vacía.");
                }
            } while (string.IsNullOrWhiteSpace(gravedad));

            posicion_paciente[index] = (byte)(index + 1);
            nombre_paciente[index] = nombre;
            cédula_paciente[index] = cedula;
            consulta_paciente[index] = consulta;
            gravedad_paciente[index] = gravedad;
            Console.WriteLine("Paciente agregado exitosamente.");
        }
        static void BuscarPacientes(Byte[] posicion_paciente, String[] nombre_paciente, String[] cedula_paciente, String[] consulta_paciente, String[] gravedad_paciente, Byte n)
        {
            Console.WriteLine("\n---Busquemos un paciente---\n");
            Console.WriteLine("Ingresa el número de cédula del paciente que deseas encontrar: ");
            string buscador = Console.ReadLine();
            bool encontrado = false;

            for (byte i = 0; i < n; i++)
            {
                if (buscador == cedula_paciente[i])
                {
                    Console.WriteLine("");
                    Console.WriteLine("Posición: " + posicion_paciente[i]);
                    Console.WriteLine("Nombre: " + nombre_paciente[i]);
                    Console.WriteLine("Cédula: " + cedula_paciente[i]);
                    Console.WriteLine("Consulta: " + consulta_paciente[i]);
                    Console.WriteLine("Gravedad: " + gravedad_paciente[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
        static void ModificarPaciente(Byte[] posicion_paciente, String[] nombre_paciente, String[] cedula_paciente, String[] consulta_paciente, String[] gravedad_paciente, Byte n)
        {
            Console.WriteLine("\n---Modificar paciente---\n");
            Console.WriteLine("Ingrese la cédula del paciente que desea modificar: ");
            string buscador = Console.ReadLine();
            bool encontrado = false;
            for (byte i = 0; i < n; i++)
            {
                if (buscador == cedula_paciente[i])
                {
                    Console.WriteLine("Ingrese el nuevo nombre del paciente: ");
                    nombre_paciente[i] = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva cédula del paciente: ");
                    cedula_paciente[i] = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva consulta del paciente: ");
                    consulta_paciente[i] = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva gravedad del paciente: ");
                    gravedad_paciente[i] = Console.ReadLine();
                    Console.WriteLine("Paciente modificado exitosamente.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
        static void EliminarPaciente(Byte[] posicion_paciente, String[] nombre_paciente, String[] cedula_paciente, String[] consulta_paciente, String[] gravedad_paciente, Byte n)
        {
            Console.WriteLine("\n---Eliminar paciente---\n");
            Console.WriteLine("Ingrese la cédula del paciente que desea eliminar: ");
            string buscador = Console.ReadLine();
            bool encontrado = false;
            for (byte i = 0; i < n; i++)
            {
                if (buscador == cedula_paciente[i])
                {
                    nombre_paciente[i] = null;
                    cedula_paciente[i] = null;
                    consulta_paciente[i] = null;
                    gravedad_paciente[i] = null;
                    Console.WriteLine("Paciente eliminado exitosamente.");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
        static void MostrarLista(Byte[] posicion_paciente, String[] nombre_paciente, String[] cedula_paciente, String[] consulta_paciente, String[] gravedad_paciente, Byte n)
        {
            Console.WriteLine("\n---Lista de pacientes registrados---\n");
            bool hayPacientes = false;
            for (byte i = 0; i < n; i++)
            {
                if (cedula_paciente[i] != null)
                {
                    Console.WriteLine("Posición: " + posicion_paciente[i]);
                    Console.WriteLine("Nombre: " + nombre_paciente[i]);
                    Console.WriteLine("Cédula: " + cedula_paciente[i]);
                    Console.WriteLine("Consulta: " + consulta_paciente[i]);
                    Console.WriteLine("Gravedad: " + gravedad_paciente[i]);
                    Console.WriteLine("------------------------");
                    hayPacientes = true;
                }
            }
            if (!hayPacientes)
            {
                Console.WriteLine("No hay pacientes registrados en este momento.");
            }
        }
    }
}