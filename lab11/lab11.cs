#region Semantic Analyzer
void Semantic_Analysis(int k)
{
    if (finalArray[k].Equals("+"))
    {
        if (variable_Reg.Match(finalArray[k - 1] + "").Success && variable_Reg.Match(finalArray[k + 1] + "").Success)
        {
            String type = finalArray[k - 4] + "";
            String left_side = finalArray[k - 3] + "";
            int left_side_i = 0;
            int left_side_j = 0;
            String before = finalArray[k - 1] + "";
            int before_i = 0;
            int before_j = 0;
            String after = finalArray[k + 1] + "";
            int after_i = 0;
            int after_j = 0;
            for (int i = 0; i < Symboltable.Count; i++)
            {
                for (int j = 0; j < Symboltable[i].Count; j++)
                {
                    if (Symboltable[i][j].Equals(left_side))
                    { left_side_i = i; left_side_j = j; }
                    if (Symboltable[i][j].Equals(before))
                    { before_i = i; before_j = j; }
                    if (Symboltable[i][j].Equals(after))
                    { after_i = i; after_j = j; }
                }
            }
            if (type.Equals(Symboltable[before_i][2]) && type.Equals(Symboltable[after_i][2]) && Symboltable[before_i][2].Equals(Symboltable[after_i][2]))
            {
                int Ans = Convert.ToInt32(Symboltable[before_i][3]) + Convert.ToInt32(Symboltable[after_i][3]);
                Constants.Add(Ans);
            }
            if (Symboltable[left_side_i][2].Equals(Symboltable[before_i][2]) &&
            Symboltable[left_side_i][2].Equals(Symboltable[after_i][2]) && Symboltable[before_i][2].Equals(Symboltable[after_i][2]))
            {
                int Ans = Convert.ToInt32(Symboltable[before_i][3]) + Convert.ToInt32(Symboltable[after_i][3]);
                Constants.RemoveAt(Constants.Count - 1);
                Constants.Add(Ans);
                Symboltable[left_side_i][3] = Ans + "";
            }
        }
    }
    if (finalArray[k].Equals("-"))
    {
        if (variable_Reg.Match(finalArray[k - 1] + "").Success && variable_Reg.Match(finalArray[k + 1] + "").Success)
        {
            String type = finalArray[k - 4] + "";
            String left_side = finalArray[k - 3] + "";
            int left_side_i = 0;
            int left_side_j = 0;
            String before = finalArray[k - 1] + "";
            int before_i = 0;
            int before_j = 0;
            String after = finalArray[k + 1] + "";
            int after_i = 0;
            int after_j = 0;
            for (int i = 0; i < Symboltable.Count; i++)
            {
                for (int j = 0; j < Symboltable[i].Count; j++)
                {
                    if (Symboltable[i][j].Equals(left_side))
                    { left_side_i = i; left_side_j = j; }
                    if (Symboltable[i][j].Equals(before))
                    { before_i = i; before_j = j; }
                    if (Symboltable[i][j].Equals(after))
                    { after_i = i; after_j = j; }
                }
            }
            if (type.Equals(Symboltable[before_i][2]) && type.Equals(Symboltable[after_i][2]) && Symboltable[before_i][2].Equals(Symboltable[after_i][2]))
            {
                int Ans = Convert.ToInt32(Symboltable[before_i][3]) - Convert.ToInt32(Symboltable[after_i][3]);
                Constants.Add(Ans);
            }
            if (Symboltable[left_side_i][2].Equals(Symboltable[before_i][2]) && Symboltable[left_side_i][2].Equals(Symboltable[after_i][2]) && Symboltable[before_i][2].Equals(Symboltable[after_i][2]))
            {
                int Ans = Convert.ToInt32(Symboltable[before_i][3]) + Convert.ToInt32(Symboltable[after_i][3]);
                Constants.RemoveAt(Constants.Count - 1);
                Constants.Add(Ans);
                Symboltable[left_side_i][3] = Ans + "";
            }
        }
    }
    if (finalArray[k].Equals(">"))
    {
        if (variable_Reg.Match(finalArray[k - 1] + "").Success && variable_Reg.Match(finalArray[k + 1] + "").Success)
        {
            String before = finalArray[k - 1] + "";
            int before_i = 0;
            int before_j = 0;
            String after = finalArray[k + 1] + "";
            int after_i = 0;
            int after_j = 0;
            for (int i = 0; i < Symboltable.Count; i++)
            {
                for (int j = 0; j < Symboltable[i].Count; j++)
                {
                    if (Symboltable[i][j].Equals(before))
                    { before_i = i; before_j = j; }
                    if (Symboltable[i][j].Equals(after))
                    { after_i = i; after_j = j; }
                }
            }
            if (Convert.ToInt32(Symboltable[before_i][3]) > Convert.ToInt32(Symboltable[after_i][3]))
            {
                int start_of_else = finalArray.IndexOf("else");
                int end_of_else = finalArray.Count - 1;
                for (int i = end_of_else; i >= start_of_else; i--)
                {
                    if (finalArray[i].Equals("}"))
                    {
                        if (i < finalArray.Count - 2)
                        { end_of_else = i; }
                    }
                }
                for (int i = start_of_else; i <= end_of_else; i++)
                { finalArray.RemoveAt(start_of_else); }
            }
            else
            {
                int start_of_if = finalArray.IndexOf("if");
                int end_of_if = finalArray.IndexOf("}");
                for (int i = start_of_if; i <= end_of_if; i++)
                { finalArray.RemoveAt(start_of_if); }
                if_deleted = true;
            }
        }
    }
}
#endregion