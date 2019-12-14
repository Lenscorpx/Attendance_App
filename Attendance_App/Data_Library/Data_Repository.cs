using MaterialSkin.Controls;
using MetroFramework.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Attendance_App.Forms_Library;

namespace Attendance_App.Data_Library
{
    public class Data_Repository
    {
        static SqlConnection cnx;
        Params prms = new Params();
        public Data_Repository()
        {
            //prms.Serveur = "tcp:conebase.database.windows.net";                    
            //prms.Nom_user = "LensX";
            //prms.Mot_de_passe = "Cony@2017.com?";



            //prms.Serveur = "JOHNSEVEN";
            //prms.Base_de_donnees = "db_kkdependants";
            //prms.Nom_user = "sa";
            //prms.Mot_de_passe = "123456789";
            prms.Serveur = "DESKTOP-PO0I2OH";
            prms.Base_de_donnees = "db_attendance";
            prms.Nom_user = "sa";
            prms.Mot_de_passe = "Windy@2019.com?";
            //prms.Serveur = "DESKTOP-3M7GUQ9";
            //prms.Base_de_donnees = "db_kkdependants";
            //prms.Nom_user = "sa";
            //prms.Mot_de_passe = "Admin123_";
        }
        public void verifier_dependant(string id_dependent, Label existance)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("verifier_dependant", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_dependents", SqlDbType.NVarChar)).Value = id_dependent;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    existance.Text = "1";
                }
                else
                {
                    existance.Text = "0";
                }
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur de chargement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_ville(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_ville", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_ville(string id_ville, string denomination)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_ville", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_ville", SqlDbType.NVarChar)).Value = id_ville;
                cmd.Parameters.Add(new SqlParameter("denomination", SqlDbType.NVarChar)).Value = denomination;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_ville(string id_ville)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_ville", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_ville", SqlDbType.NVarChar)).Value = id_ville;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void recuperer_combobox_ville(MetroComboBox cbx)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("recuperer_combobox_ville", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //cmd.Parameters.Add(new SqlParameter("complete_name", SqlDbType.NVarChar)).Value = search_name;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                cbx.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cbx.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_liens(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_liens", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_lien(string id_lien, string description_lien)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_lien", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_lien", SqlDbType.NVarChar)).Value = id_lien;
                cmd.Parameters.Add(new SqlParameter("description_lien", SqlDbType.NVarChar)).Value = description_lien;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_lien(string id_lien)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_lien", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_lien", SqlDbType.NVarChar)).Value = id_lien;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void recuperer_combobox_lien(MetroComboBox cbx)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("recuperer_combobox_lien", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //cmd.Parameters.Add(new SqlParameter("complete_name", SqlDbType.NVarChar)).Value = search_name;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                cbx.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cbx.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_structure(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_structure", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_structure(string id_structure, string designation_structure, string id_ville)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_structure", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_structure", SqlDbType.NVarChar)).Value = id_structure;
                cmd.Parameters.Add(new SqlParameter("designation_structure", SqlDbType.NVarChar)).Value = designation_structure;
                cmd.Parameters.Add(new SqlParameter("id_ville", SqlDbType.NVarChar)).Value = id_ville;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_structure(string id_structure)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_structure", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_structure", SqlDbType.NVarChar)).Value = id_structure;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void recuperer_combo_structure(MetroComboBox cbx, string id_ville)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("recuperer_combo_structure", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_ville", SqlDbType.NVarChar)).Value = id_ville;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                cbx.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cbx.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_agent(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_agent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_agent(string code_agent, string noms, DateTime date_naissance, string telephone, string adresse, string sexe, byte[] photo)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_agent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("code_agent", SqlDbType.NVarChar)).Value = code_agent;
                cmd.Parameters.Add(new SqlParameter("noms", SqlDbType.NVarChar)).Value = noms;
                cmd.Parameters.Add(new SqlParameter("date_naissance", SqlDbType.Date)).Value = date_naissance;
                cmd.Parameters.Add(new SqlParameter("telephone", SqlDbType.NVarChar)).Value = telephone;
                cmd.Parameters.Add(new SqlParameter("adresse", SqlDbType.NVarChar)).Value = adresse;
                cmd.Parameters.Add(new SqlParameter("sexe", SqlDbType.NVarChar)).Value = sexe;
                cmd.Parameters.Add(new SqlParameter("photo", SqlDbType.Image)).Value = photo;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_agent(string code_agent)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_agent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("code_agent", SqlDbType.NVarChar)).Value = code_agent;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void recherche_listbox_agent(ListBox lst, string search_name)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("recherche_listbox_agent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@searchname", SqlDbType.NVarChar)).Value = search_name;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                lst.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void recuperer_listbox_agent(ListBox lst)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("recuperer_listbox_agent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                lst.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }


        
        public void retrieve_combo_organization(ComboBox cbx)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("retrieve_combo_organization", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //cmd.Parameters.Add(new SqlParameter("complete_name", SqlDbType.NVarChar)).Value = search_name;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                cbx.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cbx.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Echec de connexion!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void retrieve_combo_zone(ComboBox cbx)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("retrieve_combo_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //cmd.Parameters.Add(new SqlParameter("complete_name", SqlDbType.NVarChar)).Value = search_name;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                cbx.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cbx.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Echec de connexion!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void retrieve_combo_level(ComboBox cbx)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("retrieve_combo_level", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //cmd.Parameters.Add(new SqlParameter("complete_name", SqlDbType.NVarChar)).Value = search_name;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                cbx.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cbx.Items.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Echec de connexion!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_employees(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_employees", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_employees_full(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_employees_full", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_accesslevel_infos_code(Label lvl_access, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_accesslevel_infos_code", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lvl_access.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_zone_infos_code(DataGridView dtg, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_zone_infos_code", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_infos_code(TextBox lbl_name, TextBox lbl_function, TextBox lbl_organisation, TextBox lbl_contact, TextBox lbl_adress, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_infos_code", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lbl_name.Text = Convert.ToString(dr[0]);
                    lbl_function.Text = Convert.ToString(dr[1]);
                    lbl_organisation.Text = Convert.ToString(dr[2]);
                    lbl_contact.Text = Convert.ToString(dr[3]);
                    lbl_adress.Text = Convert.ToString(dr[4]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }        
        public void search_employee_byid(DataGridView dtg, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byid", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_employee_byname(DataGridView dtg, string noms_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byname", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("noms_emp", SqlDbType.NVarChar)).Value = noms_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_employee_byfonction(DataGridView dtg, string id_fonction)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byfonction", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_fonction", SqlDbType.NVarChar)).Value = id_fonction;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }        
        public void search_employee_byorganisation(DataGridView dtg, string id_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byorganisation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }        
        public void enregistrer_employee(string id_emp, string noms_emp, string adresse, string num_phone, string id_fonction, string id_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_employee", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.Parameters.Add(new SqlParameter("noms_emp", SqlDbType.NVarChar)).Value = noms_emp;
                cmd.Parameters.Add(new SqlParameter("adresse", SqlDbType.NVarChar)).Value = adresse;
                cmd.Parameters.Add(new SqlParameter("num_phone", SqlDbType.NVarChar)).Value = num_phone;
                cmd.Parameters.Add(new SqlParameter("id_fonction", SqlDbType.NVarChar)).Value = id_fonction;
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void modifier_employee(int num_emp, string id_emp, string noms_emp, string adresse, string num_phone, string id_fonction, string id_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("modifier_employee", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_emp", SqlDbType.Int)).Value = num_emp;
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.Parameters.Add(new SqlParameter("noms_emp", SqlDbType.NVarChar)).Value = noms_emp;
                cmd.Parameters.Add(new SqlParameter("adresse", SqlDbType.NVarChar)).Value = adresse;
                cmd.Parameters.Add(new SqlParameter("num_phone", SqlDbType.NVarChar)).Value = num_phone;
                cmd.Parameters.Add(new SqlParameter("id_fonction", SqlDbType.NVarChar)).Value = id_fonction;
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Modification avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_employee(int num_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_employee", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_emp", SqlDbType.Int)).Value = num_emp;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Suppression reussie!", "Suppression des enregistrements", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_employee_byid_full(DataGridView dtg, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byid_full", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_employee_byname_full(DataGridView dtg, string noms_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byname_full", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("noms_emp", SqlDbType.NVarChar)).Value = noms_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_employee_byfonction_full(DataGridView dtg, string id_fonction)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byfonction_full", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_fonction", SqlDbType.NVarChar)).Value = id_fonction;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_employee_byorganisation_full(DataGridView dtg, string id_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_employee_byorganisation_full", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_attendance(DateTime date_attendance, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_attendance", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("date_attendance", SqlDbType.Date)).Value = date_attendance;
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.Parameters.Add(new SqlParameter("time_attendance", SqlDbType.DateTime)).Value =Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Attendance!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }       
        public void afficher_attendance(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_attendance", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_attendance_byid(DataGridView dtg, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_attendance_byid", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_attendance_byname(DataGridView dtg, string noms_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_attendance_byname", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("noms_emp", SqlDbType.NVarChar)).Value = noms_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_attendance_byorganisation(DataGridView dtg, string id_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_attendance_byorganisation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_affectation_zone(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_affectation_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_affectation_zone(string id_level_access, string id_zone, DateTime date_affec_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_affectation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_level_access", SqlDbType.NVarChar)).Value = id_level_access;
                cmd.Parameters.Add(new SqlParameter("id_zone", SqlDbType.NVarChar)).Value = id_zone;
                cmd.Parameters.Add(new SqlParameter("date_affec_zone", SqlDbType.DateTime)).Value = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void modifier_affectation_zonen(int num_affec_zone, string id_level_access, string id_zone, DateTime date_affec_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("modifier_affectation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_affec_zone", SqlDbType.Int)).Value = num_affec_zone;
                cmd.Parameters.Add(new SqlParameter("id_level_access", SqlDbType.NVarChar)).Value = id_level_access;
                cmd.Parameters.Add(new SqlParameter("id_zone", SqlDbType.NVarChar)).Value = id_zone;
                cmd.Parameters.Add(new SqlParameter("date_affec_zone", SqlDbType.DateTime)).Value = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_affectation_zone(int num_affec_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_affectation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_affec_zone", SqlDbType.Int)).Value = num_affec_zone;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_affec_zone_by_id_level_access(DataGridView dtg, string id_level_access)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_affec_zone_by_id_level_access", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_level_access", SqlDbType.NVarChar)).Value = id_level_access;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_affec_zone_by_id_zone(DataGridView dtg, string id_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_affec_zone_by_id_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_zone", SqlDbType.NVarChar)).Value = id_zone;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_accreditation(string id_emp,string id_level_access,  DateTime date_expiration, string state_accred)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_accreditation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };                
                cmd.Parameters.Add(new SqlParameter("date_accreditation", SqlDbType.Date)).Value = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.Parameters.Add(new SqlParameter("id_level_access", SqlDbType.NVarChar)).Value = id_level_access;
                cmd.Parameters.Add(new SqlParameter("date_expiration", SqlDbType.Date)).Value = date_expiration;
                cmd.Parameters.Add(new SqlParameter("state_accred", SqlDbType.NVarChar)).Value = state_accred;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void modifier_accreditation(int num_accreditation, string id_emp, string id_level_access, DateTime date_expiration, string state_accred)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("modifier_accreditation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_accreditation", SqlDbType.Int)).Value = num_accreditation;
                cmd.Parameters.Add(new SqlParameter("date_accreditation", SqlDbType.Date)).Value = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.Parameters.Add(new SqlParameter("id_level_access", SqlDbType.NVarChar)).Value = id_level_access;
                cmd.Parameters.Add(new SqlParameter("date_expiration", SqlDbType.Date)).Value = date_expiration;
                cmd.Parameters.Add(new SqlParameter("state_accred", SqlDbType.NVarChar)).Value = state_accred;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_accreditation(int num_accreditation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_accreditation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_accreditation", SqlDbType.Int)).Value = num_accreditation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_accreditation(DataGridView dtg, string id_emp)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_accreditation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_emp", SqlDbType.NVarChar)).Value = id_emp;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_accreditation(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_accreditation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_zone(string id_zone, string descr_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_zone", SqlDbType.NVarChar)).Value = id_zone;
                cmd.Parameters.Add(new SqlParameter("descr_zone", SqlDbType.NVarChar)).Value = descr_zone;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void modifier_zone(int num_zone, string id_zone, string descr_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("modifier_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_zone", SqlDbType.Int)).Value = num_zone;
                cmd.Parameters.Add(new SqlParameter("id_zone", SqlDbType.NVarChar)).Value = id_zone;
                cmd.Parameters.Add(new SqlParameter("descr_zone", SqlDbType.NVarChar)).Value = descr_zone;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_zone(int num_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_zone", SqlDbType.Int)).Value = num_zone;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_zone(DataGridView dtg, string id_zone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_zone", SqlDbType.NVarChar)).Value = id_zone;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_zone(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_zone", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_organisation(string id_organisation, string nom_organisation, string descr_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_organisation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.Parameters.Add(new SqlParameter("nom_organisation", SqlDbType.NVarChar)).Value = nom_organisation;
                cmd.Parameters.Add(new SqlParameter("descr_organisation", SqlDbType.NVarChar)).Value = descr_organisation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void modifier_organisation(int num_org, string id_organisation, string nom_organisation, string descr_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("modifier_organisation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_org", SqlDbType.Int)).Value = num_org;
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.Parameters.Add(new SqlParameter("nom_organisation", SqlDbType.NVarChar)).Value = nom_organisation;
                cmd.Parameters.Add(new SqlParameter("descr_organisation", SqlDbType.NVarChar)).Value = descr_organisation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_organisation(int num_org)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_organisation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_org", SqlDbType.Int)).Value = num_org;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_organisation(DataGridView dtg, string id_organisation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_organisation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_organisation", SqlDbType.NVarChar)).Value = id_organisation;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_organisation(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_organisation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_level(string id_level_access, string descr_access, DateTime date_access)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_level", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_level_access", SqlDbType.NVarChar)).Value = id_level_access;
                cmd.Parameters.Add(new SqlParameter("descr_access", SqlDbType.NVarChar)).Value = descr_access;
                cmd.Parameters.Add(new SqlParameter("date_access", SqlDbType.Date)).Value = date_access;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void modifier_level(int num_access, string id_level_access, string descr_access, DateTime date_access)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("modifier_level", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_access", SqlDbType.Int)).Value = num_access;
                cmd.Parameters.Add(new SqlParameter("id_level_access", SqlDbType.NVarChar)).Value = id_level_access;
                cmd.Parameters.Add(new SqlParameter("descr_access", SqlDbType.NVarChar)).Value = descr_access;
                cmd.Parameters.Add(new SqlParameter("date_access", SqlDbType.Date)).Value = date_access;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_level(int num_access)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_level", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_access", SqlDbType.Int)).Value = num_access;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succes!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_level(DataGridView dtg, string id_access_level)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_level", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_access_level", SqlDbType.NVarChar)).Value = id_access_level;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Erreur d'execution ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_level(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_level", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }












        public void rechercher_code_agent(MaterialSingleLineTextField txt, string search_name)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_code_agent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("noms", SqlDbType.NVarChar)).Value = search_name;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                txt.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    txt.Text = Convert.ToString(dr[0]);
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        
        public void enregistrer_dependent(string id_dependents, string noms, DateTime date_naissance,
                        string sexe, string adresse, string id_lien, byte[] photo, string code_agent)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_dependent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_dependents", SqlDbType.NVarChar)).Value = id_dependents;
                cmd.Parameters.Add(new SqlParameter("noms", SqlDbType.NVarChar)).Value = noms;
                cmd.Parameters.Add(new SqlParameter("date_naissance", SqlDbType.Date)).Value = date_naissance;
                cmd.Parameters.Add(new SqlParameter("sexe", SqlDbType.NVarChar)).Value = sexe;
                cmd.Parameters.Add(new SqlParameter("adresse", SqlDbType.NVarChar)).Value = adresse;
                cmd.Parameters.Add(new SqlParameter("id_lien", SqlDbType.NVarChar)).Value = id_lien;
                cmd.Parameters.Add(new SqlParameter("photo", SqlDbType.Image)).Value = photo;
                cmd.Parameters.Add(new SqlParameter("code_agent", SqlDbType.NVarChar)).Value = code_agent;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_dependents(string id_dependents)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_dependents", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_dependents", SqlDbType.NVarChar)).Value = id_dependents;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_dependents(DataGridView dtg, string code_agent)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_dependents", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("code_agent", SqlDbType.NVarChar)).Value = code_agent;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_nom_dependents(DataGridView dtg, string noms)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_nom_dependents", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("noms", SqlDbType.NVarChar)).Value = noms;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_affectation(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_affectation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void inserer_affectation(string code_agent, string id_structure, DateTime date_affectation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("inserer_affectation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("code_agent", SqlDbType.NVarChar)).Value = code_agent;
                cmd.Parameters.Add(new SqlParameter("id_structure", SqlDbType.NVarChar)).Value = id_structure;
                cmd.Parameters.Add(new SqlParameter("date_affectation", SqlDbType.Date)).Value = date_affectation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void modifier_affectation(int num_affectation, string code_agent, string id_structure, DateTime date_affectation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("modifier_affectation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_affectation", SqlDbType.Int)).Value = num_affectation;
                cmd.Parameters.Add(new SqlParameter("code_agent", SqlDbType.NVarChar)).Value = code_agent;
                cmd.Parameters.Add(new SqlParameter("id_structure", SqlDbType.NVarChar)).Value = id_structure;
                cmd.Parameters.Add(new SqlParameter("date_affectation", SqlDbType.Date)).Value = date_affectation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_affectation(int num_affectation)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_affectation", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("num_affectation", SqlDbType.Int)).Value = num_affectation;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_affectation_paragent(DataGridView dtg, string code_agent)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_affectation_paragent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("code_agent", SqlDbType.NVarChar)).Value = code_agent;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_affectation_parstructure(DataGridView dtg, string id_structure)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_affectation_parstructure", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_structure", SqlDbType.NVarChar)).Value = id_structure;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void remplir_node_enfant(TreeNode node_parent, string noms_agent)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("treeview_charge_byname", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("noms", SqlDbType.Int)).Value = noms_agent;

                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    {
                        TreeNode child = new TreeNode();
                        child.Text = dr["Name"].ToString().Trim();
                        string temp = dr["IID"].ToString();
                        child.Collapse();
                        node_parent.Nodes.Add(child);
                        remplir_node_enfant(child, temp);
                    }
                }
            }
            catch (Exception etr)
            {
                MessageBox.Show("Erreur lors du chargement!", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Message d'erreur", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(etr.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }

        }
        public void remplir_treeview(TreeView trvw)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                const string requete = "treeview_distinct";
                var cmd = new SqlCommand(requete, cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                trvw.Nodes.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[2] != null)
                    {
                        TreeNode tnParent = new TreeNode();
                        tnParent.Text = dr[1].ToString();
                        string value = dr[0].ToString();
                        tnParent.Expand();
                        trvw.Nodes.Add(tnParent);
                        remplir_node_enfant(tnParent, value);
                    }
                }
            }
            catch (Exception etr)
            {
                MessageBox.Show("Erreur lors du chargement!", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous consulter le message d'erreur?", "Message d'erreur", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(etr.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void liste_dependants_structure(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("liste_dependants_structure", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_dependants_structure_paragent(DataGridView dtg, string noms_agent)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_dependants_structure_paragent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("noms_agent", SqlDbType.NVarChar)).Value = noms_agent;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_code_dependents(DataGridView dtg, string code_dependant)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_code_dependents", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_dependents", SqlDbType.NVarChar)).Value = code_dependant;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_dependants_structure_parstructure(DataGridView dtg, string id_structure)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_dependants_structure_parstructure", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_structure", SqlDbType.NVarChar)).Value = id_structure;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void rechercher_login(string username, string pwd, int y)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("rechercher_login", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar)).Value = username;
                cmd.Parameters.Add(new SqlParameter("@pwd", SqlDbType.NVarChar)).Value = pwd;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    y = 1;
                   // var fr = new frm_params ();
                   // fr.Show();
                    cnx.Close(); cnx.Dispose();
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas acces a cette application, Veuillez consulter le DSI!");
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_nombre_agent(Label nombre_agent)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_nombre_agent", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nombre_agent.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_nombre_conjoint(Label nombre_conjoint)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_nombre_conjoint", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nombre_conjoint.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_nombre_dependants(Label nombre_dependant)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_nombre_dependants", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nombre_dependant.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_nombre_enfants(Label nombre_enfant)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_nombre_enfants", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nombre_enfant.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_nombre_familles(Label nombre_famille)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_nombre_familles", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nombre_famille.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_nombre_filles(Label nombre_filles)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_nombre_filles", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nombre_filles.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_nombre_garcons(Label nombre_garcons)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_nombre_garcons", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    nombre_garcons.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void charts_sans_dependants(Label sans_dependants)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("charts_sans_dependants", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    sans_dependants.Text = Convert.ToString(dr[0]);
                    cnx.Close(); cnx.Dispose();
                }
            }
            catch (Exception tdf)
            {
                MessageBox.Show("Connection failed!\n" + tdf);
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
    }
}
