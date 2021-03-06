﻿using Expelibrum.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Expelibrum.UI.ViewModels
{
    public interface INameTaggingViewModel
    {
        ICommand AddTagCommand { get; }
        IEnumerable<string> SelectedTags { get; }
        ObservableCollection<NameTagViewModel> TagVMs { get; }
    }
}