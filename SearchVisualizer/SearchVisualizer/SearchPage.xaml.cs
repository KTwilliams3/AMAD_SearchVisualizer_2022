namespace SearchVisualizer;

public partial class SearchPage : ContentPage
{
	int[] values = { 2, 4, 6, 12, 15, 15, 23, 31, 33, 33, 36, 40, 41, 56, 58, 68, 72, 73, 81, 99 };
	List<Label> labels = new List<Label>();
	int delay = 100;

	public SearchPage()
	{
		InitializeComponent();
		LoadValues();
	}

	async void LinearSearch(object sender, EventArgs args)
	{
		int target = Convert.ToInt32(targetEntry.Text);

		for (int i = 0; i < values.Length; i++)
		{
			labels[i].BackgroundColor = Colors.Yellow;
			await NextStep(delay);
			if(values[i] == target)
			{
				labels[i].BackgroundColor = Colors.Cyan;
				await NextStep(delay);
				return;
			}
			else
			{
				labels[i].BackgroundColor = Colors.Black;
				await NextStep(delay);
			}
		}
	}

	async void BinarySearch(object sender, EventArgs args)
	{
        int target = Convert.ToInt32(targetEntry.Text);

		int lower = 0;
		int upper = values.Length - 1;
		
		while(lower <= upper)
		{
			int mid = (lower + upper) / 2;
			labels[mid].BackgroundColor = Colors.Yellow;
            await NextStep(delay);

            if (values[mid] == target)
			{
				labels[mid].BackgroundColor = Colors.Cyan;
				await NextStep(delay);
				return;
			}
			else if (values[mid] < target)
			{
				lower = mid + 1;
			}
			else
			{
				upper = mid - 1;
			}
		}
    }

	async Task NextStep(int delay)
	{
		hSL.Clear();
		foreach (var label in labels)
		{
			hSL.Add(label);
		}
		await Task.Delay(delay);
	}

		void LoadValues()
	{
		for (int i = 0; i < values.Length; i++)
		{
			Label label = new Label();
			label.Text = values[i].ToString();
			label.HorizontalTextAlignment = TextAlignment.Center;
			label.BackgroundColor = Colors.Gray;
			label.TextColor = Colors.White;
			label.WidthRequest = 18;
			labels.Add(label);
		}

		hSL.Children.Clear();
		foreach (Label label in labels)
		{
			hSL.Add(label);
		}
	}

	void ResetValues(object sender, EventArgs args)
	{
		hSL.Clear();
		labels.Clear();
		LoadValues();
	}
}