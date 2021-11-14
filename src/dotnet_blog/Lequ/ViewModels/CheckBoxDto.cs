namespace Lequ.ViewModels
{
    public class CheckBoxDto
    {
        public CheckBoxDto()
        {
        }

        public CheckBoxDto(string text, int value, bool isChecked = false)
        {
            Text = text;
            Value = value;
            Checked = isChecked;
        }

        public int Value { get; set; }

        public string? Text { get; set; }

        public bool Checked { get; set; }
    }
}