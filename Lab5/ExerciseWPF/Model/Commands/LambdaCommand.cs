﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseWPF.Model.Commands
{
    class LambdaCommand : BaseCommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<Object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<Object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object Parameter) => _CanExecute?.Invoke(Parameter) ?? true;
        public override void Execute(object Parameter) => _Execute(Parameter);
    }
}
