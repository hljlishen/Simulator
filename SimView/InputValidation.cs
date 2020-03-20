using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimView
{
    public class InputValidation
    {
        private Dictionary<TextBox, StringRule> ruleMap = new Dictionary<TextBox, StringRule>();
        private Dictionary<TextBox, string> textBeforeChange = new Dictionary<TextBox, string>();
        public ErrorProvider errorProvider = new ErrorProvider() {BlinkStyle = ErrorBlinkStyle.NeverBlink };
        public bool ForbiddenOutRangeInput { get; set; } = false;
        public event Action<TextBox, StringRule> UnvalidatedInput;
        public void AddValidation(TextBox tb, StringRule rule)
        {
            if (ruleMap.ContainsKey(tb))
                return;

            tb.TextChanged += Tb_TextChanged;
            ruleMap.Add(tb, rule);

            if (rule.Pass(tb.Text))
                textBeforeChange.Add(tb, tb.Text);
            else
                throw new TextBoxValueDoesntMatchRuleException($"<{tb.Name}>的Text属性值不满足正则表达式:{rule.RegexExpression}");
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
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
            errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider.BlinkRate = 200;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var t = sender as System.Windows.Forms.Timer;
            t.Stop();
            t.Tick -= Timer_Tick;
            t.Dispose();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
    }

    public class TextBoxValueDoesntMatchRuleException : Exception
    {
        public TextBoxValueDoesntMatchRuleException(string message) : base(message)
        {
        }
    }
}
