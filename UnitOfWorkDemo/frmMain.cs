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
            Dosomething(EnumRepositoryType.InMemory, false);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.InMemory, false);
        }


        private void cmdWorkWithHHibRepo_Click(object sender, EventArgs e)
        {
            Dosomething(EnumRepositoryType.NHibernate, false);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.NHibernate, false);
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

        private void Dosomething(EnumRepositoryType repoType, bool light)
        {
            int deleteIndex = 0;
            int editIndex = 0;
            int count = 0;
            try
            {
                if (light)
                {
                    using (UnitOfWorkNhibernate work = new UnitOfWorkNhibernate())
                    {
                        string data;

                        count = work.PearsonRepository.Get().Count();

                        work.PearsonRepository.Create(new Entities.Pearson { Id = 1, FirstName = "Peter", LastName = "Topolšek" });
                        work.PearsonRepository.Create(new Entities.Pearson { Id = 2, FirstName = "Peter", LastName = "Topolšek" });
                        work.PearsonRepository.Create(new Entities.Pearson { Id = 3, FirstName = "Peter", LastName = "Topolšek" });
                        //work.Save();
                        deleteIndex = GetDeleteIndex(count);
                        editIndex = GetEditIndex(count);

                        data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());
                        MessageBox.Show("Before edit: \n" + data);


                        work.PearsonRepository.Update(new Entities.Pearson { Id = 2, FirstName = "Katarina", LastName = "Ročnik" });
                        work.PearsonRepository.Delete(3);
                        //work.Save();

                        data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());
                        MessageBox.Show("After edit: \n" + data);


                        MessageBox.Show("Final result: \n" + data + "\n Število vseh: " + work.PearsonRepository.Get().Count().ToString());

                        if(chkRaiseError.Checked)
                            throw new Exception("Error, nothing should be saved");

                        work.Save();
                    }
                }
                else
                {
                    using (UnitOfWork work = new UnitOfWork(repoType))
                    {
                        string data;

                        work.PearsonRepository.Create(new Entities.Pearson { FirstName = "Peter", LastName = "Topolšek" });
                        work.PearsonRepository.Create(new Entities.Pearson { FirstName = "Peter", LastName = "Topolšek" });
                        work.PearsonRepository.Create(new Entities.Pearson { FirstName = "Peter", LastName = "Topolšek" });
                        work.Save();

                        data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());
                        MessageBox.Show("Before edit: \n" + data);

                        Pearson editPearson = work.PearsonRepository.GetByIndex(1);
                        
                        work.PearsonRepository.Update(new Entities.Pearson { Id = 2, FirstName = "Katarina", LastName = "Ročnik" });
                        work.PearsonRepository.Delete(3);
                        work.Save();

                        data = string.Join(",", work.PearsonRepository.Get().Select(p => p.FirstName).ToArray());
                        MessageBox.Show("After edit: \n" + data);


                        MessageBox.Show("Final result: \n" + data + "\n Število vseh: " + work.PearsonRepository.Get().Count().ToString());

                        if (chkRaiseError.Checked)
                            throw new Exception("Error, the object was saved, because every method is wraped in transaction");

                        work.Save();
                    }
                }
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
            if (light)
            {
                using (UnitOfWorkNhibernate work = new UnitOfWorkNhibernate())
                {
                    return work.PearsonRepository.Get();
                }
            }
            else
            {
                using (UnitOfWork work = new UnitOfWork(repoType))
                {
                    return work.PearsonRepository.Get();
                }
            }
            
        }
        #endregion

        private void cmdNHibLight_Click(object sender, EventArgs e)
        {
            Dosomething(EnumRepositoryType.NHibernate, true);
            dgPearsons.DataSource = GetAll(EnumRepositoryType.NHibernate, true);
        }
    }
}
