using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDeudas
{
    class Program
    {
        static void Main(string[] args)
        {
            Program programa = new Program();
            List<DeudasGenericas> deudas = new List<DeudasGenericas>();

            byte opcion = 0;

            while (opcion != 11)
            {
                DeudasGenericas deudores = null;
                programa.menu();

                opcion = byte.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        deudores = new DeudasGenericas();
                        programa.agregarDeuda(deudores);
                        deudas.Add(deudores);
                        break;
                    case 2:
                        deudores = new DeudasBancarias();
                        programa.agregarDeuda(deudores);
                        programa.AgregarDeudaBancaria(deudores);
                        deudas.Add(deudores);
                        break;
                    case 3:
                        programa.modificarPagado(deudas);
                        break;
                    case 4:
                        programa.eliminarDeuda(deudas);
                        break;

                    case 5:
                        programa.modificarCuotas(deudas);
                        break;
                    case 6:
                        programa.modificarMontoTotal(deudas);
                        break;
                    case 7:
                        programa.modificarItem(deudas);
                        break;
                    case 8:
                        programa.MostrarTotal(deudas);
                        break;
                    case 9:
                        programa.MostrarDeudasBancarias(deudas);
                        break;
                    case 10:
                        programa.MostrarTotalGenricas(deudas);
                        break;
                    default:
                        break;
                }
            }
            Console.Clear();
        }

        void menu()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("1)Agregar Deuda");
            Console.WriteLine("2)Agregar DeudaBancaria");
            Console.WriteLine("3)Modificar montoPagado");
            Console.WriteLine("4)Eliminar Deuda");
            Console.WriteLine("5)Modificar Cantidad de Cuotas");
            Console.WriteLine("6)Modificar montoTotal");
            Console.WriteLine("7)Modificar nombre de deuda");
            Console.WriteLine("8)Mostrar Total a Pagar");
            Console.WriteLine("9)Mostrar Total a Pagar Deudas Bancarias");
            Console.WriteLine("10)Mostrar Total a Pagar Deudas no Bancarias");
            Console.WriteLine("11)Salir");
        }

        void agregarDeuda(DeudasGenericas D)
        {
            Console.Clear();
            Console.WriteLine("Ingresar Código");
            D.codigo = Console.ReadLine();
            Console.WriteLine("Ingresar Monto Total");
            D.montoTotal = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar Item");
            D.item = Console.ReadLine();
            Console.WriteLine("Ingrese Fecha");
            D.fecha = Console.ReadLine();

        }

        void AgregarDeudaBancaria(DeudasGenericas D)
        {
            Console.WriteLine("Ingresar n° de cuotas");
            ((DeudasBancarias)D).cuotas = byte.Parse(Console.ReadLine());
            Console.WriteLine("Igresar Monto de Cuotas");
            ((DeudasBancarias)D).montoCuota = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar Monto Pagado");
            ((DeudasBancarias)D).montoTotal = int.Parse(Console.ReadLine());


        }

        void modificarPagado(List<DeudasGenericas> DG)
        {
            Console.Clear();
            Console.WriteLine("Ingrese codigo que desea modificar");

            string code = Console.ReadLine();

            DeudasGenericas actualizar = DG.Where(x => x.codigo == code).FirstOrDefault();

            if (((DeudasBancarias)actualizar) != null)
            {
                Console.WriteLine("Ingrese monto a actualizar");
                ((DeudasBancarias)actualizar).montoPagado = int.Parse(Console.ReadLine());

            }
        }

        void modificarCuotas(List<DeudasGenericas> DG)
        {
            Console.Clear();
            Console.WriteLine("Ingrese codigo de la deuda para modificar cuota");
            string code = Console.ReadLine();

            DeudasGenericas ActCuota = DG.Where(x => x.codigo == code).FirstOrDefault();

            if (((DeudasBancarias)ActCuota) != null)
            {
                Console.WriteLine("Ingrese numero de cuotas");
                ((DeudasBancarias)ActCuota).cuotas = byte.Parse(Console.ReadLine());
                Console.WriteLine($"Cuota modificada, ahora las cuotas son: {((DeudasBancarias)ActCuota).cuotas}");
                Console.WriteLine("Para verificar, vaya al menu principal y busque la deuda correspondiente(opcion 9 y 10)");
            }
        }

        void modificarMontoTotal(List<DeudasGenericas> DG)
        {
            Console.Clear();
            Console.WriteLine("Ingrese codigo de deuda para modificar monto");
            string code = Console.ReadLine();

            DeudasGenericas ActMonTotal = DG.Where(x => x.codigo == code).FirstOrDefault();

            if (ActMonTotal != null)
            {
                Console.WriteLine("Ingrese monto");
                ActMonTotal.montoTotal = int.Parse(Console.ReadLine());
                Console.WriteLine($"Monto total modificado, ahora las cuotas son: {((DeudasBancarias)ActMonTotal).montoTotal}");
                Console.WriteLine("Para verificar, vaya al menu principal y busque la deuda correspondiente(opcion 9 y 10)");
            }
            else
            {
                Console.WriteLine("No existe ese codigo de deuda");
            }
        }

        void modificarItem(List<DeudasGenericas> DG)
        {
            Console.Clear();
            Console.WriteLine("Ingrese codigo de item a modificar");
            string code = Console.ReadLine();

            DeudasGenericas ActItem = DG.Where(x => x.codigo == code).FirstOrDefault();

            if (ActItem != null)
            {
                Console.WriteLine("Ingrese nuevo item");
                ActItem.item = Console.ReadLine();
                Console.WriteLine($"Item modificado, ahora será: {((DeudasBancarias)ActItem).item}");
                Console.WriteLine("Para verificar, vaya al menu principal y busque la deuda correspondiente(opcion 9 y 10)");
            }
            else
            {
                Console.WriteLine("No existe ese codigo de deuda");
            }
        }

        void eliminarDeuda(List<DeudasGenericas>DG)
        {
            Console.Clear();
            foreach (DeudasGenericas deuda in DG)
            {
                Console.WriteLine("Deudas Registradas");
                Console.WriteLine(deuda.codigo);
            }

            Console.WriteLine("Ingresar Código de deuda a eliminar");
            string code = Console.ReadLine();

            DeudasGenericas eliminar = DG.Where(x=> x.codigo==code).FirstOrDefault();

            if (eliminar != null)
            {
                DG.Remove(eliminar);
                Console.WriteLine("Deuda eliminada");
            }
            else
            {
                Console.WriteLine("No existe ese codigo de deuda");
            }
        }

        void MostrarTotal(List<DeudasGenericas> DG)
        {
            Console.Clear();
            
             int total = 0;
             foreach (DeudasGenericas item in DG)
             {
                  total = total + item.montoTotal;
             }
                  Console.WriteLine($"El total de las deudas es: {total}");
            
            
        }

        void MostrarDeudasBancarias(List<DeudasGenericas> DG)
        {
            Console.Clear();
            Console.WriteLine("Ingrese codigo de deuda bancaria ");
            string code = Console.ReadLine();

            DeudasGenericas BuscarBancarias = DG.Where(x => x.codigo == code).FirstOrDefault();
            if (((DeudasBancarias)BuscarBancarias) != null)
            {
                Console.WriteLine($"La deuda tiene un monto total de: ${BuscarBancarias.montoTotal} por: {BuscarBancarias.item}");
                Console.WriteLine($"Cuotas: { ((DeudasBancarias)BuscarBancarias).cuotas}");
                Console.WriteLine($"Monto cuota: { ((DeudasBancarias)BuscarBancarias).montoCuota}");
                Console.WriteLine($": { ((DeudasBancarias)BuscarBancarias).montoCuota}");
            }
            else
            {
                Console.WriteLine("Deuda bancaria no existe");
            }
        
        }

        void MostrarTotalGenricas(List<DeudasGenericas> DG)
        {
            Console.Clear();
            Console.WriteLine("Ingrese codigo de deuda");
            string code = Console.ReadLine();

            DeudasGenericas BuscarDeuda = DG.Where(x=> x.codigo==code).FirstOrDefault();
            if (BuscarDeuda !=null)
            {
                Console.WriteLine($"El monto a pagar es: ${BuscarDeuda.montoTotal} por consumo de: {BuscarDeuda.item}");
                
            }
            else
            {
                Console.Write("Deuda generica no existe");
            }
        }
        
    }
}
