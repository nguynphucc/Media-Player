﻿using MuViPApp.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuViPApp
{
    public partial class form_Music_AllPlaylist : Form
    {
        private Music_Playlist listpl;

        Form_Muvip parent;

        public form_Music_AllPlaylist(Form_Muvip parent)
        {
            this.parent = parent;
            InitializeComponent();
            ShowPlayList(this.parent.ID_Account);
        }

        void ShowPlayList(string ID)
        {
            string sqlQuery = "USP_Playlist @ID_Acc";
            DataTable result = DataProvider.Instance.ExecuteQuery(sqlQuery, new object[] { ID });
            List<Music_Playlist> listpl = new List<Music_Playlist>();
            for (int i = 0; i < result.Rows.Count; i++)
            {
                Music_Playlist music_Playlist = new Music_Playlist(result.Rows[i].Field<string>(0), result.Rows[i].Field<string>(1), result.Rows[i].Field<int>(2));
                listpl.Add(music_Playlist);
                FLP_playlist.Controls.Add(listpl[i]);
            }
        }

        #region Events
        
        #endregion
    }
}
