using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace ZCXJ_CS.UI
{
    public partial class ListGridView<T> : UserControl where T : new()
    {
        public event DataGridViewBindingCompleteEventHandler DataBindingComplete;
        public new event EventHandler BindingContextChanged;
        public event DataGridViewCellEventHandler CellValueChanged;
        public event DataGridViewCellEventHandler CellClick;
        public Dictionary<string, string> Captions;
        private DataTable datatable;
        private List<T> lst;
        private int pagesize = 20;
        private int pageindex = 1;

        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value; }
        }

        public bool ReadOnly
        {
            get { return GridView.ReadOnly; }
            set { GridView.ReadOnly = value; }
        }

        public bool AllowUserToAddRows
        {
            get { return GridView.AllowUserToAddRows; }
            set { GridView.AllowUserToAddRows = value; }
        }

        public bool AllowPage
        {
            get { return GridPage.Visible; }
            set
            {
                GridPage.Visible = value;
                MainsplitContainer.Panel2Collapsed = !value;
            }
        }

        public ListGridView()
        {
            InitializeComponent();
            Captions = new Dictionary<string, string>();
            datatable = new DataTable();
            GridPage.OnPageChange += GridPage_OnPageChange;
        }

        private void GridPage_OnPageChange(int Index)
        {
            List<T> change = new List<T>();
            lst = DataList;
            int max = pagesize * Index > lst.Count ? lst.Count : pagesize * Index;
            for (int i = pagesize * (Index - 1); i < max; i++)
            {
                change.Add(lst[i]);
            }
            foreach(var item in change)
            {
                lst.Remove(item);
            }
            datatable = ToDataTable(change);
            DataRefresh();
            pageindex = Index;
        }

        /// <summary>
        /// List类型数据源
        /// </summary>
        public List<T> DataList
        {
            get
            {
                List<T> ret = new List<T>(lst);
                var change = ToList(datatable);
                ret.InsertRange((pageindex - 1) * pagesize, change);
                return ret;
            }
            set
            {
                GridPage.PageCount = value.Count / pagesize + (value.Count % pagesize > 0 ? 1 : 0);
                lst = value;
                var tempCount = GridPage.PageCount > 1 ? pagesize : value.Count;
                var chang = lst.Take(tempCount).ToList();
                lst.RemoveRange(0, tempCount);
                datatable = ToDataTable(chang);
                AllowPage = GridPage.PageCount > 1;
            }
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public void DataRefresh()
        {
            GridView.DataSource = datatable;
        }

        /// <summary>
        /// 获取选中项
        /// </summary>
        public List<T> SelectItems
        {
            get
            {
                List<T> lst = new List<T>();
                if (GridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dr in GridView.SelectedRows)
                    {
                        lst.Add(ToModel((DataRowView)dr.DataBoundItem));
                    }
                }
                return lst;
            }
        }

        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private DataTable ToDataTable(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                Type PropertyType = property.PropertyType.Name.Contains("Nullable") ? typeof(uint) : property.PropertyType;
                dt.Columns.Add(property.Name, PropertyType);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        /// <summary>
        /// 将DataTable转换成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<T> ToList(DataTable dt)
        {
            List<T> ts = new List<T>();
            foreach (DataRowView dr in dt.DefaultView)
            {
                T t = ToModel(dr);
                ts.Add(t);
            }
            return ts;
        }

        /// <summary>
        /// 将数据行转化成数据实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private T ToModel(DataRowView dr)
        {
            T t = new T();
            string tempName = "";
            PropertyInfo[] propertys = t.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                tempName = pi.Name;
                if (!pi.CanWrite) continue;
                object value = dr[tempName];
                if (value != DBNull.Value)
                    pi.SetValue(t, value, null);
            }
            return t;
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick.Invoke(sender, e);
            }
        }

        private void GridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CellValueChanged != null)
            {
                CellValueChanged.Invoke(sender, e);
            }
        }

        private void GridView_BindingContextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView.Columns.Count; i++)
            {
                if (Captions.ContainsKey(GridView.Columns[i].Name))
                {
                    GridView.Columns[i].HeaderText = Captions[GridView.Columns[i].Name];
                    GridView.Columns[i].MinimumWidth = 80;
                }
            }
            if (BindingContextChanged != null)
            {
                BindingContextChanged.Invoke(sender, e);
            }
        }

        private void GridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataBindingComplete != null)
            {
                DataBindingComplete.Invoke(sender, e);
            }
        }
    }
}
