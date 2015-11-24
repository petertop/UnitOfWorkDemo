using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StructureMap;
using UnitOfWorkDemo.Services;

namespace UnitOfWorkDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IMessageService service = ObjectFactory.GetInstance<IMessageService>();

                MessageBox.Show(service.GetMessage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void cmdWorkWithRepository_Click(object sender, EventArgs e)
        {
            using(UnitOfWork work = new UnitOfWork())
            {
                work.PearsonRepository.Create(new Entities.Pearson { Id = 1, FirstName = "Peter", LastName = "Topolšek" });
                work.PearsonRepository.Create(new Entities.Pearson { Id = 2, FirstName = "Peter", LastName = "Topolšek" });
                work.PearsonRepository.Create(new Entities.Pearson { Id = 3, FirstName = "Peter", LastName = "Topolšek" });
                work.PearsonRepository.Update(new Entities.Pearson { Id = 2, FirstName = "Katarina", LastName = "Ročnik" });
                work.PearsonRepository.Delete(3);

                work.Save();

                MessageBox.Show(work.PearsonRepository.Get().Count().ToString());

                string data = string.Join(",", work.PearsonRepository.Get().Select(p=>p.FirstName).ToArray());

                MessageBox.Show(data);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // todo
        }
    }
}
