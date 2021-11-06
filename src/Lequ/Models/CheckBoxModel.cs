namespace Lequ.Models
{

    public class CheckBoxModel
    {
        public CheckBoxModel()
        {
        }

        public CheckBoxModel(string text, int value, bool isChecked = false)
        {
            this.Text = text;
            this.Value = value;
            this.Checked = isChecked;
        }

        public int Value { get; set; }

        public string? Text { get; set; }

        public bool Checked { get; set; }
    }
}
