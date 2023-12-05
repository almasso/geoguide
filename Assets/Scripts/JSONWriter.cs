using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JSONWriter : Save_Load
{
    public Nivel_Info myLevel_writer = new Nivel_Info();
    StringBuilder sbText = new StringBuilder();
    StringBuilder sbText2 = new StringBuilder();

    public Card myCard_writer = new Card();
    StringBuilder sbCard = new StringBuilder();

    public void outputJSON()
    {
        myLevel_writer.name = myLevel_Info_List.nivel_Info[IndexController._index].name;
        myLevel_writer.intentos = Random.Range(0, 3).ToString(); //luego cambiarlo


        string line = "";
        using (var reader = new System.IO.StreamReader(level_Info_path_real))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(myLevel_writer.name))
                {
                    line = "\"name\"" + ":" + "\"" + myLevel_writer.name + "\"" + "," + "\n" +
                           "\"intentos\"" + ":" + "\"" + myLevel_writer.intentos + "\"" + ",";
                    sbText.AppendLine(line);
                    line = reader.ReadLine();
                    changeLevelButton();
                }
                else
                {
                    sbText.AppendLine(line);
                }
            }
        }
        File.WriteAllText(level_Info_path_real, sbText.ToString());
    }

    public void cardJSON(int cardIndex) // como conseguir card index(??)
    {
        string line = "";
        using (var reader = new System.IO.StreamReader(cards_info_path))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("\"" + "index" + "\"" + ":" + " " + cardIndex + ","))
                {
                    sbCard.AppendLine(line);
                    line = reader.ReadLine();
                    line = "\"isActive\"" + ":" + " " + "true" + ",";
                    sbCard.AppendLine(line);
                }
                else
                {
                    sbCard.AppendLine(line);
                }
            }
        }
        File.WriteAllText(cards_info_path, sbCard.ToString());
    }

    private void changeLevelButton()
    {
        using (var reader = new System.IO.StreamReader(levels_path_real))
        {
            string line2 = "";
            while ((line2 = reader.ReadLine()) != null)
            {
                if (line2.Contains("\"" + "index" + "\"" + ":" + " " + IndexController._index.ToString() + ","))
                {
                    sbText2.AppendLine(line2);
                    line2 = reader.ReadLine(); sbText2.AppendLine(line2); 
                    reader.ReadLine();
                    switch (myLevel_writer.intentos)
                    {
                        case "0" :
                            line2 = "\"" + "estrella1" + "\"" + ":" + "true" + ","; sbText2.AppendLine(line2); reader.ReadLine(); 
                            line2 = "\"" + "estrella2" + "\"" + ":" + "true" + ","; sbText2.AppendLine(line2); reader.ReadLine();
                            line2 = "\"" + "estrella3" + "\"" + ":" + "true"; sbText2.AppendLine(line2); 
                            break;
                        case "1" :
                            line2 = "\"" + "estrella1" + "\"" + ":" + "true" + ","; sbText2.AppendLine(line2); reader.ReadLine(); 
                            line2 = "\"" + "estrella2" + "\"" + ":" + "true" + ","; sbText2.AppendLine(line2); reader.ReadLine();
                            line2 = "\"" + "estrella3" + "\"" + ":" + "false"; sbText2.AppendLine(line2); 
                            break;
                        case "2" :
                            line2 = "\"" + "estrella1" + "\"" + ":" + "true" + ","; sbText2.AppendLine(line2); reader.ReadLine();
                            line2 = "\"" + "estrella2" + "\"" + ":" + "false" + ","; sbText2.AppendLine(line2); reader.ReadLine(); 
                            line2 = "\"" + "estrella3" + "\"" + ":" + "false"; sbText2.AppendLine(line2); 
                            break;
                        default:
                            line2 = "\"" + "estrella1" + "\"" + ":" + "false" + ","; sbText2.AppendLine(line2); reader.ReadLine(); 
                            line2 = "\"" + "estrella2" + "\"" + ":" + "false" + ","; sbText2.AppendLine(line2); reader.ReadLine(); 
                            line2 = "\"" + "estrella3" + "\"" + ":" + "false"; sbText2.AppendLine(line2); 
                            break;
                    }
                }
                else
                {
                    sbText2.AppendLine(line2);
                }
            }
        }

        File.WriteAllText(levels_path_real, sbText2.ToString());
    }
}