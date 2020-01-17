for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                    {
                        MySqlConnection conn = new MySqlConnection(cs.myconnection1);
                        conn.Open();
                        string fquery = "select availablequantity from food where  food_name ='" + ListView1.Items[j].SubItems[2].Text + "'";
                        MySqlCommand mycommand11 = new MySqlCommand(fquery, conn);
                        string prev_value = mycommand11.ExecuteScalar().ToString();

                        if (Convert.ToInt32(prev_value) < 1)
                        {
                            MessageBox.Show( "Food out of stock");
                            return;
                        }
                        else if (Convert.ToInt32(prev_value) < Convert.ToInt32(ListView1.Items[j].SubItems[1].Text))
                        {
                            MessageBox.Show( "More products than the available quantity");
                            return;
                        }

                    }
