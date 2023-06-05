using ArchitecturePatterns.Part4.PipeFilter;

var data = new Data {Value = "Test value"};

var pipeline = new Pipeline();
pipeline.AddFilter(new ReverseFilter());
pipeline.AddFilter(new UppercaseFilter());

Console.WriteLine($"Pipeline input:{data.Value}");
Console.WriteLine($"Pipeline output:{pipeline.Process(data).Value}");
