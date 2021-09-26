using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot_Challenge
{    
    public partial class Form1 : Form
    {
        public List<string> commands;
        public List<string> filelines;
        public List<Robot> list_of_active_robots;
        public Robot active_robot;
        public bool first_command;
        public ReadFile file;
        private int current_active_robot = 1;
        
        public Form1()
        {
            InitializeComponent();
            commands = new List<string>();            
            first_command = true;
            file = new ReadFile();
            filelines = new List<string>();
            list_of_active_robots = new List<Robot>();
            active_robot = new Robot(1);
            list_of_active_robots.Add(active_robot);
        }

        //This method selects which robot command to call from the robot class based off the string input
        public void SelectCommand(string input)
        {
            Regex rgx = new Regex("^((MOVE)|(REPORT)|(LEFT)|(RIGHT)|(ROBOT<[1-9]\\d*>))$", RegexOptions.IgnoreCase);
            Regex place = new Regex("^PLACE [0-5],[0-5],(north|south|east|west)$", RegexOptions.IgnoreCase);
            //first call can't be move, report, left or right
            if (rgx.IsMatch(input) && first_command)
            {                
                return;
            }
            //first call must be a place
            else if (place.IsMatch(input) && first_command)
            {
                active_robot = active_robot.Place(active_robot, input);                
                first_command = false;
            }
            //not first call, but move, report, left, right or select active robot command
            else if (rgx.IsMatch(input) && !first_command)
            {
                Regex match_robot_command = new Regex("^ROBOT<[1-9]\\d*>", RegexOptions.IgnoreCase);
                //check if it's a select active robot command
                if(match_robot_command.IsMatch(input))
                {
                    Regex match_digits_only = new Regex("[^0-9]");
                    int index = int.Parse(match_digits_only.Replace(input, ""));
                    if (index <= list_of_active_robots.Count())
                    {
                        active_robot = list_of_active_robots[index - 1];
                        current_active_robot = index;
                    }
                    else
                    {
                        txtbox_invalidinputcommands.AppendText($"{input} is not a valid command" + Environment.NewLine);
                    }                    
                }
                else
                {
                    switch (input.ToUpper())
                    {
                        case "MOVE":
                            active_robot = active_robot.Move(active_robot);
                            break;
                        case "REPORT":
                            txtbox_output.AppendText($"Number of robots {list_of_active_robots.Count()}, active robot {current_active_robot}, current status: " + Report(active_robot) + Environment.NewLine);
                            break;
                        case "LEFT":
                            active_robot.current_orientation = active_robot.Left(active_robot.current_orientation);
                            break;
                        case "RIGHT":
                            active_robot.current_orientation = active_robot.Right(active_robot.current_orientation);
                            break;
                        default:
                            return;
                    }
                }     
            }            
            //not a first call but a place command            
            else if(place.IsMatch(input) && !first_command)
            {
                current_active_robot = list_of_active_robots.Count() + 1;
                Robot new_robot = new Robot(list_of_active_robots.Count() + 1);
                list_of_active_robots.Add(new_robot);                
                active_robot = new_robot;
                active_robot = active_robot.Place(active_robot, input);
            }
            //do nothing if nothing matches
            else
            {                
                return;
            }
        }

        public string Report(Robot robot)
        {
            return $"{robot.current_x_position},{robot.current_y_position},{robot.current_orientation}";
        }

        //Read input textbox
        private void btn_readinputs_Click(object sender, EventArgs e)
        {
            commands.Clear();
            txtbox_output.Clear();
            txtbox_invalidinputcommands.Clear();
            for (int i = 0; i < txtbox_input.Lines.Length; i++)
            {
                if (active_robot.CheckValidInput(txtbox_input.Lines[i]))
                {
                    commands.Add(txtbox_input.Lines[i]);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtbox_input.Lines[i]))
                    {
                        txtbox_invalidinputcommands.AppendText($"You entered whitespace or no characters at line {i}, this is invalid" + Environment.NewLine);
                    }
                    else
                    {
                        txtbox_invalidinputcommands.AppendText($"{txtbox_input.Lines[i]} at line {i} is invalid" + Environment.NewLine);
                    }
                }
            }
            foreach (string value in commands)
            {
                SelectCommand(value);
            }
        }

        //Read file
        private void btn_readfromfile_Click(object sender, EventArgs e)
        {
            filelines.Clear();
            txtbox_input.Clear();
            txtbox_output.Clear();
            txtbox_invalidinputcommands.Clear();            
            first_command = true;
            int i = 0;
            try
            {
                filelines = file.ReadTextFile(txtbox_filelocation.Text);
                foreach (string value in filelines)
                {
                    if (active_robot.CheckValidInput(value))
                    {
                        txtbox_input.AppendText(value + Environment.NewLine);
                        SelectCommand(value);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            txtbox_invalidinputcommands.AppendText($"You entered whitespace or no characters at line {i}, this is invalid" + Environment.NewLine);
                        }
                        else
                        {
                            txtbox_invalidinputcommands.AppendText($"{value} at line {i} is invalid" + Environment.NewLine);
                        }
                    }
                    i++;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                txtbox_filelocation.Text = "No valid file found";
            }
            catch (System.ArgumentException)
            {
                txtbox_filelocation.Text = "Please enter a valid file location path";
            }
        }

        private void btn_validcommands_Click(object sender, EventArgs e)
        {
            HelpForm helpform = new HelpForm();
            helpform.ShowDialog();
        }
    }
}
