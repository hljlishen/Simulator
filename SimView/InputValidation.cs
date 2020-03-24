using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimView
{
    public class InputValidation
    {
        private Dictionary<Control, StringRule> ruleMap = new Dictionary<Control, StringRule>();
        private Dictionary<Control, string> textBeforeChange = new Dictionary<Control, string>();
        public ErrorProvider errorProvider = new ErrorProvider() {BlinkStyle = ErrorBlinkStyle.NeverBlink };
        public bool ForbiddenOutRangeInput { get; set; } = false;
        public event Action<Control, StringRule> UnvalidatedInput;
        public Control CueControl { get; set; }
        public void AddValidation(Control tb, StringRule rule)
        {
            if (ruleMap.ContainsKey(tb))
                return;

            tb.TextChanged += Tb_TextChanged;
            ruleMap.Add(tb, rule);

            if (rule.Pass(tb.Text))
                textBeforeChange.Add(tb, tb.Text);
            else
                throw new TextBoxValueDoesntMatchRuleException($"<{tb.Name}>的Text属性值不满足正则表达式:{rule.ToString()}");
        }

        private void Tb_TextChanged(object sender, System.EventArgs e)
        {
            TextBox tb = sender as TextBox;
            StringRule rule = ruleMap[tb];

            if (rule.Pass(tb.Text))
            {
                textBeforeChange[tb] = tb.Text;
                errorProvider.SetError(tb, "");
                return;
            }

            else
            {
                errorProvider.SetError(tb, rule.Hint);
                if(ForbiddenOutRangeInput)
                    tb.Text = textBeforeChange[tb];
                UnvalidatedInput?.Invoke(tb, rule);
            }
        }

        public bool IsAllInputsValidate()
        {
            foreach (var tb in ruleMap.Keys)
            {
                if (errorProvider.GetError(tb) != "")
                    return false;
            }
            return true;
        }

        public void Cue()
        {
            var timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
            errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider.BlinkRate = 200;
            if(CueControl != null)
            {
                if (CueControl.ForeColor != Color.Red)
                    CueControl.ForeColor = Color.Red;
                CueControl.Text = "输入存在错误，请检查";
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var t = sender as Timer;
            t.Stop();
            t.Tick -= Timer_Tick;
            t.Dispose();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            if (CueControl != null)
            {
                CueControl.Text = "";
            }
        }
    }

    public class TextBoxValueDoesntMatchRuleException : Exception
    {
        public TextBoxValueDoesntMatchRuleException(string message) : base(message)
        {
        }
    }
}
