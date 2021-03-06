﻿using NHibernate;
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


        #region Event Handlers
        private void cmdWorkWithRepository_Click(object sender, EventArgs e)
        {
            using (IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("BasicUOWNHib"))
            {
                work.RepositoryType = EnumRepositoryType.NHibernate;
                Dosomething(EnumRepositoryType.InMemory, false, work, chkShowMessages.Checked);
            }
            GetCountsAndFillDataGrids();
        }


        private void cmdWorkWithHHibRepo_Click(object sender, EventArgs e)
        {
            using (IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("LightUOW"))
            {
                work.RepositoryType = EnumRepositoryType.NHibernate;
                Dosomething(EnumRepositoryType.NHibernate, true, work, chkShowMessages.Checked);
            }
            GetCountsAndFillDataGrids();
        }


        private void cmdNHibLight_Click(object sender, EventArgs e)
        {
            // Direct call, without using
            IUnitOfWork work = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWork>("LightUOW");
            Dosomething(EnumRepositoryType.NHibernate, true, work, chkShowMessages.Checked);
            
            // Should end call with disposing, otherwise transction hangs up...
            work.Dispose();
            GetCountsAndFillDataGrids();
        }


        private void cmdUseGenericRepo_Click(object sender, EventArgs e)
        {
            try
            {
                using (IUnitOfWorkGeneric genericWork = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWorkGeneric>("GenericUOW"))
                {
                    //genericWork.BeginTransaction();

                    genericWork.LogRepository.Create(new Log { Description = "Test", Created = DateTime.Now });

                    DosomethingWithOrders(EnumRepositoryType.NHibernate, chkRaiseError.Checked, genericWork, false);

                    if (chkRaiseError.Checked)
                        throw new Exception("Error, abort transaction...");

                    genericWork.Commit();
                }
                GetCountsAndFillDataGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }


        private void cmdMessage_Click(object sender, EventArgs e)
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
        #endregion



        #region Methods
        private void GetCountsAndFillDataGrids()
        {
            try
            {
                IList<Pearson> pearsonList = null;
                IList<Order> ordersList = null;
                IList<Log> logList = null;

                using (IUnitOfWorkGeneric genericWork = StructureMap.ObjectFactory.GetNamedInstance<IUnitOfWorkGeneric>("GenericUOW"))
                {
                    ordersList = genericWork.OrderRepository.GetAll().ToList();
                    pearsonList = genericWork.PearsonRepository.GetAll().ToList();
                    logList = genericWork.LogRepository.GetAll().ToList();
                }

                dgPearsons.DataSource = pearsonList;
                dgOrders.DataSource = ordersList;
                dgLogs.DataSource = logList;

                lblLogCount.Text = logList.Count.ToString();
                lblPearsonCounts.Text = pearsonList.Count.ToString();
                lblOrdersCount.Text = ordersList.Count.ToString();

                lblTime.Text = "At: " + DateTime.Now.ToShortTimeString();
                lblStatistics.Text = "Total pearsons returned: " + pearsonList.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

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

                lblStatistics.Text = "Total pearsons returned: " + count.ToString();

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
                    throw new Exception("Error, nothing should be saved or everything, depends of UnitOfWork/Repository combination you pick...");

                work.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: \n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void DosomethingWithOrders(EnumRepositoryType repoType, bool useSingleTransaction, IUnitOfWorkGeneric work, bool showMessages)
        {
            int editIndex = 0;
            int count = 0;
            try
            {
                // Get current count
                count = work.PearsonRepository.GetAll().Count();

                lblStatistics.Text = "Total pearsons returned: " + count.ToString();


                // Add new pearson and orders
                Pearson newPearson = new Entities.Pearson { FirstName = "Marko", LastName = "Novak" };

                newPearson = work.PearsonRepository.Create(newPearson);

                newPearson = work.PearsonRepository.GetById(newPearson.Id);

                newPearson.Orders.Add(new Order { Pearson = newPearson, Price = 45, Subject = "Some demo text..." });

                newPearson.Orders.Add(new Order { Pearson = newPearson, Price = 53, Subject = "More demo text..." });

                // Add Orders on created pearson
                editIndex = GetEditIndex(count);

                lblStatistics.Text = lblStatistics.Text + ", Edit index: " + editIndex.ToString();

                Pearson updatePearson = work.PearsonRepository.GetAll().ToArray()[editIndex];

                updatePearson.Orders.Add(new Order { Pearson = updatePearson, Price = 45, Subject = "Some demo text..." });

                updatePearson.Orders.Add(new Order { Pearson = updatePearson, Price = 53, Subject = "More demo text..." });

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
        #endregion
    }
}
