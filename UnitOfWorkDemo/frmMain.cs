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
    // REferences
    // http://www.codeproject.com/Articles/380022/Simplify-Database-Operations-with-Generic-Fluent-N
    // http://jasonwatmore.com/post/2015/01/28/Unit-of-Work-Repository-Pattern-in-MVC5-with-Fluent-NHibernate-and-Ninject.aspx

    public partial class frmMain : Form
    {
        // Fields
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
            IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("BasicUOWNHib");

            work.RepositoryType = EnumRepositoryType.NHibernate;

            Dosomething(EnumRepositoryType.InMemory, false, work, chkShowMessages.Checked);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.InMemory, false);
        }


        private void cmdWorkWithHHibRepo_Click(object sender, EventArgs e)
        {
            IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("LightUOW");

            Dosomething(EnumRepositoryType.NHibernate, true, work, chkShowMessages.Checked);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.NHibernate, false);
        }


        private void cmdHelloHib_Click(object sender, EventArgs e)
        {
            IList<Pearson> pearsonList = null;

            IPearsonRepository pearsonRepo = StructureMap.ObjectFactory.GetNamedInstance<IPearsonRepository>("NHibRepo");

            pearsonList = pearsonRepo.Get().ToList();

            dgPearsons.DataSource = pearsonList;

            lblStatistics.Text = "Total records returned: " + pearsonList.Count;

            return;

            INHibernateSessionFactory sessionFactory = StructureMap.ObjectFactory.GetInstance<INHibernateSessionFactory>();

            using (var session = sessionFactory.CreateSessionFactory().OpenSession())
            {
                string h_stmt = "FROM Pearson";

                IQuery query = session.CreateQuery(h_stmt);

                pearsonList = query.List<Pearson>();

                dgPearsons.DataSource = pearsonList;

                lblStatistics.Text = "Total records returned: " + pearsonList.Count;

            }

        }


        #region Methods

        private void Dosomething(EnumRepositoryType repoType, bool useSingleTransaction, IUnitOfWork work, bool showMessages)
        {
            int deleteIndex = 0;
            int editIndex = 0;
            int count = 0;
            try
            {
                string data;

                // Get current count
                count = work.PearsonRepository.Get().Count();

                work.PearsonRepository.Create(new Entities.Pearson { FirstName = "Peter", LastName = "Topolšek" });
                work.PearsonRepository.Create(new Entities.Pearson { FirstName = "Peter", LastName = "Topolšek" });

                if (!useSingleTransaction)
                    work.Save();

                deleteIndex = GetDeleteIndex(count);
                editIndex = GetEditIndex(count);

                data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());

                if (showMessages)
                    MessageBox.Show("Before edit: \n" + data);

                Pearson updatePearson = work.PearsonRepository.Get().ToArray()[editIndex];

                updatePearson.FirstName = "Katarina";
                updatePearson.LastName = "Ročnik";


                work.PearsonRepository.Update(updatePearson);

                Pearson deletePearson = work.PearsonRepository.Get().ToArray()[deleteIndex];

                work.PearsonRepository.Delete(deletePearson.Id);

                if (!useSingleTransaction)
                    work.Save();

                data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());
                if (showMessages)
                    MessageBox.Show("After edit: \n" + data);

                if (showMessages)
                    MessageBox.Show("Final result: \n" + data + "\n Število vseh: " + work.PearsonRepository.Get().Count().ToString());

                if (chkRaiseError.Checked)
                    throw new Exception("Error, nothing should be saved or everything, depends of UOW provider you pick...");

                work.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.Message);
            }
        }

        private int GetEditIndex(int count)
        {
            if (count > 2)
                return count - 2;
            else
                return count;
        }

        private int GetDeleteIndex(int count)
        {
            if (count > 1)
                return count - 1;
            else
                return count;
        }

        private IEnumerable<Pearson> GetAll(EnumRepositoryType repoType, bool light)
        {
            IList<Pearson> pearsonList = null;
            if (light)
            {
                using (IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("LightUOW"))
                {
                    work.RepositoryType = EnumRepositoryType.NHibernate;
                    pearsonList = work.PearsonRepository.Get().ToList();
                }
            }
            else
            {
                using (IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("BasicUOWNHib"))
                {
                    work.RepositoryType = EnumRepositoryType.NHibernate;
                    pearsonList = work.PearsonRepository.Get().ToList();
                }
            }

            return pearsonList;

        }
        #endregion

        private void cmdNHibLight_Click(object sender, EventArgs e)
        {
            IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("LightUOW");
            Dosomething(EnumRepositoryType.NHibernate, true, work,chkShowMessages.Checked);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.NHibernate, true);
        }

        private void cmdUseGenericRepo_Click(object sender, EventArgs e)
        {
            try
            {
                IList<Pearson> pearsonList = null;

                using (UnitOfWorkGeneric work = new UnitOfWorkGeneric())
                {
                    pearsonList = work.PearsonRepository.GetAll().ToList();
                }

                dgPearsons.DataSource = pearsonList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
