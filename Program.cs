//Create:           1402/09/13
//Summary:          RESTful API for Sazeh Gostar Saipa. using .NET 7.0
//Documentation:    __Readme.txt
//By:               Yousef Amiri

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
         .AddJsonOptions(options =>
         {
             options.JsonSerializerOptions.Encoder= System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
         });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
