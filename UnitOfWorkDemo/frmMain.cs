using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Data.Abstract;
using UnitOfWorkDemo.Entities;
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
                IMessageService service = StructureMap.ObjectFactory.GetInstance<IMessageService>();

                MessageBox.Show(service.GetMessage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void cmdWorkWithRepository_Click(object sender, EventArgs e)
        {
            Dosomething(EnumRepositoryType.InMemory);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.InMemory);
        }


        private void cmdWorkWithHHibRepo_Click(object sender, EventArgs e)
        {
            Dosomething(EnumRepositoryType.NHibernate);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.NHibernate);
        }


        private void cmdHelloHib_Click(object sender, EventArgs e)
        {
            var sessionFactory = NHibernateFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                string h_stmt = "FROM Pearson";

                IQuery query = session.CreateQuery(h_stmt);

                IList<Pearson> pearsonList = query.List<Pearson>();

                dgPearsons.DataSource = pearsonList;

                lblStatistics.Text = "Total records returned: " + pearsonList.Count;

            }

        }


        #region Methods

        private void Dosomething(EnumRepositoryType repoType)
        {
            using (UnitOfWork work = new UnitOfWork(repoType))
            {
                string data;

                work.PearsonRepository.Create(new Entities.Pearson { Id = 1, FirstName = "Peter", LastName = "Topolšek" });
                work.PearsonRepository.Create(new Entities.Pearson { Id = 2, FirstName = "Peter", LastName = "Topolšek" });
                work.PearsonRepository.Create(new Entities.Pearson { Id = 3, FirstName = "Peter", LastName = "Topolšek" });
                work.Save();

                data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());
                MessageBox.Show("Before edit: \n" + data);


                work.PearsonRepository.Update(new Entities.Pearson { Id = 2, FirstName = "Katarina", LastName = "Ročnik" });
                work.PearsonRepository.Delete(3);
                work.Save();

                data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());
                MessageBox.Show("After edit: \n" + data);


                MessageBox.Show("Final result: \n" + data + "\n Število vseh: " + work.PearsonRepository.Get().Count().ToString());
            }
        }

        private IEnumerable<Pearson> GetAll(EnumRepositoryType repoType)
        {
            using (UnitOfWork work = new UnitOfWork(repoType))
            {
                return work.PearsonRepository.Get();
            }
        }
        #endregion
    }
}
