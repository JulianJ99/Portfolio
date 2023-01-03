using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Spotify.Business;
using Spotify.Services;

namespace SpotifyPL
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        EntityState objState = EntityState.Unchanged;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                albumBindingSource.DataSource = AlbumService.GetAll();
                    pContainer.Enabled = false;
                
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ClearInput()
        {
            txtAlbumID.Text = null;
            txtArtist.Text = null;
            txtLink.Text = null;
            txtTitle.Text = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            objState = EntityState.Added;
            pContainer.Enabled = true;
            albumBindingSource.Add(new Album());
            albumBindingSource.MoveLast();
            txtTitle.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            objState = EntityState.Changed;
            pContainer.Enabled = true;
            txtTitle.Focus();
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Album obj = albumBindingSource.Current as Album;

            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            objState = EntityState.Deleted;
            if(MetroFramework.MetroMessageBox.Show(this,"Are you sure you want to delete this album?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    Album obj = albumBindingSource.Current as Album;
                    if (obj != null)
                    {

                        bool result = AlbumService.Delete(obj.album_id);
                            if (result)
                            { 
                                albumBindingSource.RemoveCurrent();
                                pContainer.Enabled = false;
                                objState = EntityState.Unchanged;
                            }
                    }
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                albumBindingSource.EndEdit();
                Album obj = albumBindingSource.Current as Album;
                if (obj != null)
                {
                    obj = AlbumService.Save(obj, objState);
                        metroGrid1.Refresh();
                        pContainer.Enabled = false;
                        objState = EntityState.Unchanged;
                    
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
