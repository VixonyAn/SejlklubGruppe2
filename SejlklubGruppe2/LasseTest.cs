using ClassLibrary.Models;
using ClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SejlklubGruppe2
{
    public class LasseTest
    {
        public void Test()
        {
            EquipmentRepository eRepo = new EquipmentRepository();
            Equipment eq1 = new Equipment("FishingRod", "old");
            Equipment eq2 = new Equipment("FishingRod", "new");
            Equipment eq3 = new Equipment("FishingRod", "ancient");
            Equipment eq4 = new Equipment("bucket", "old");

            eRepo.AddEquipment(eq1);
            eRepo.AddEquipment(eq2);
            eRepo.AddEquipment(eq3);
            eRepo.AddEquipment(eq4);


            try
            {
                eRepo.DeleteEquipment(3);

                eRepo.DeleteEquipment(20);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
        }
        

    }
}
