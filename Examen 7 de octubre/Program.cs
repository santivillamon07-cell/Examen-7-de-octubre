// Programador: Santiago Villalobos Monge 
// Programa: Solucion rapida ante falla en sistema de datos en hospital
// Creacion de Programa: 07/10/2026
// Ultima actualizacion del programa: 07/10/2026

// Definicion de variables
const int N = 19;
string[] nombres = new string[N];    // Nombre es un vector sincronizado
string[] cedulas = new string[N];   // Nombre de segundo vector sincronizado
int cantidad = 0;
int opcion = 0;
string cedula = "";
string nombre = "";
int pos = -1;


// Iniciamos lo vectores
for (int i = 0; i < N; i++)
{
    nombres[i] = "";
    cedulas[i] = "";
}

// Menu que se repite
do
{
    Console.WriteLine();
    Console.WriteLine("1. Registrar paciente");
    Console.WriteLine("2. Buscar con cedula");
    Console.WriteLine("3. Modificar nombre");
    Console.WriteLine("4. Dar de baja");
    Console.WriteLine("5. Reporte Paciente");
    Console.WriteLine("6. Salir");
    Console.WriteLine("Elije una opcion: ");
    int.TryParse(Console.ReadLine(), out opcion);

    switch (opcion)
    {
        case 1:
            if (cantidad >= N)
            {
                Console.WriteLine("Lista llena");
            }
            else
            {
                // 1. Lee los datos
                Console.Write("Nombre: ");
                nombre = Console.ReadLine() ?? "";
                Console.Write("Cedula: ");
                cedula = Console.ReadLine() ?? "";

                // 2. Revisa si cedula ya existe
                pos = -1;
                for (int i = 0; i < cantidad; i++)
                {
                    if (cedulas[i] == cedula)
                    {
                        pos = i;
                    }
                }

                // 3. Guarda o rechaza
                if (pos != -1)
                {
                    Console.WriteLine("Cedula ya existe");
                }
                else
                {
                    nombres[cantidad] = nombre;
                    cedulas[cantidad] = cedula;
                    cantidad++;
                    Console.WriteLine("Paciente registrado");
                }
            }
            break;

        case 2:
            // 1. Lee la cedula
            Console.WriteLine("Cedula a bsucar: ");
            cedula = Console.ReadLine() ?? "";

            // 2. Buscar en el vector
            pos = -1;
            for (int i = 0; i < cantidad; i++)
            {
                if (cedulas[i] == cedula)
                {
                    pos = i;
                }
            }

            // 3. Mostrar el resultado
            if (pos == -1)
            {
                Console.WriteLine("No se encontro");
            }
            else 
            {
                Console.WriteLine("Paciente: " + nombres[pos]);
            }
            break;

        case 3:
            // 1. Lee cedula
            Console.WriteLine("Cedula del paciente: ");
            cedula = Console.ReadLine() ?? "";

            // 2. Buscar
            pos = -1;
            for (int i = 0; i < cantidad; i++)
            {
                if (cedulas[i] == cedula)
                {
                    pos = i;
                }
            }

            // 3. Corregir nombre
            if (pos == -1)
            {
                Console.WriteLine("No se encontro");
            }
            else
            {
                Console.WriteLine("Nuevo nombre: ");
                nombre = Console.ReadLine() ?? "";
                nombres[pos] = nombre;
                Console.WriteLine("Nombre actualizado");
            }
            break;

        case 4:
            // 1. Lee cedula
            Console.WriteLine("Cedula a dar de baja: ");
            cedula = Console.ReadLine() ?? "";

            // 2. Buscar
            pos = -1;
            for (int i = 0; i < cantidad; i++)
            {
                if (cedulas[i] == cedula)
                {
                    pos = i;
                }
            }

            //  3. Corre los demas a la izquierda
            if (pos == -1)
            {
                Console.WriteLine("No se encontro");
            }
            else
            {
                for (int i = pos; i < cantidad - 1; i++)
                {
                    nombres[cantidad] = nombres[i + 1];
                    cedulas[cantidad] = cedulas[i + 1];
                }
                cantidad--;
                nombres[cantidad] = "";
                cedulas[cantidad] = "";
                Console.WriteLine("Paciente dado de baja");
            }
            break;

        case 5:
            if (cantidad ==0)
            {
                Console.WriteLine("No hay pacientes registrads");
            }
            else
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine((i + 1) + ". " + nombres[i] + "- " + cedulas[i]);
                }
            }
            break;

        case 6:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opcion invalida");
            break;
    }
} while (opcion != 6);

