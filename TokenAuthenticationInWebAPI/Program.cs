using System.IdentityModel.Tokens.Jwt;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
//builder.Services
//	.AddAuthentication(options =>
//	{
//		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//		options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//	})
//	.AddJwtBearer(cfg =>
//	{
//		cfg.RequireHttpsMetadata = false;
//		cfg.SaveToken = true;
//		cfg.TokenValidationParameters = new TokenValidationParameters
//		{
//			ValidIssuer = Configuration["JwtIssuer"],
//			ValidAudience = Configuration["JwtIssuer"],
//			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
//			ClockSkew = TimeSpan.Zero // remove delay of token when expire
//		};
//	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
