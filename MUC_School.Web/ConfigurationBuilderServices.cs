using Microsoft.EntityFrameworkCore;
using MUC_School.DataAccess.Services.Implementation;
using MUC_School.DataAccess.Services.Interface;

namespace MUC_School.Web
{
	public static class ConfigurationBuilderServices
	{
		public static void Services(WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<ApplicationDbContext>(option =>
			option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}
