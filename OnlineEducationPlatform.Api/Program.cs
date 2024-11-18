
using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineEducationPlatform.BLL.Manager.AccountManager;
using OnlineEducationPlatform.BLL.Manger.Accounts;
using OnlineEducationPlatform.DAL.Repo.EnrollmentRepo;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;
using OnlineEducationPlatform.BLL.Manager.EnrollmentManager;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using OnlineEducationPlatform.DAL.Repositories;
using OnlineEducationPlatform.BLL.AutoMapper;
using OnlineQuiz.BLL.Managers.Accounts;
using Microsoft.AspNetCore.Identity;
using OnlineEducationPlatform.BLL.Manager.quizresultmanager;
using OnlineEducationPlatform.BLL.Manager.Answermanager;
using OnlineEducationPlatform.BLL.Manager.Answerresultmanager;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.AutoMapper.LectureAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.CourseAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.VideoAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuizResultAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.AnswerAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.AnswerResultAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuesionAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.EnrollmnentAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.ExamResultMapper;
using OnlineEducationPlatform.BLL.Manager.ExamResultmanager;
using OnlineEducationPlatform.BLL.AutoMapper.StudentAutoMapper;
using OnlineEducationPlatform.DAL.Repo.StudentRepo;
using OnlineEducationPlatform.BLL.Manager.StudentManager;
using OnlineEducationPlatform.BLL.AutoMapper.InstructorAutoMapper;
using OnlineEducationPlatform.DAL.Repo.InstructorRepo;
using OnlineEducationPlatform.BLL.Manager.InstructorManager;
using OnlineEducationPlatform.DAL.Repo.AnswerRepo;
using OnlineEducationPlatform.DAL.Repo.AnswerResultRepo;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.BLL.AutoMapper.QuizAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.ExamMappingProfile;
using OnlineEducationPlatform.DAL.Repo.Iexamrepo;
using OnlineEducationPlatform.BLL.Manager.ExamManager;
using Microsoft.OpenApi.Models;

namespace OnlineEducationPlatform.Api
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EducationPlatformContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            }
          );
            builder.Services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>(Options =>
            {
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = true;
                // Options.Password.RequiredLength=15;


            }).AddEntityFrameworkStores<EducationPlatformContext>().AddDefaultTokenProviders();
            builder.Services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = "JWT";//make sure token is true
                Options.DefaultChallengeScheme = "JWT";
                Options.DefaultScheme = "JWT";//return 401 => unauthorized or 403 => forbeden
            }).AddJwtBearer("JWT", Options =>
            {
                //secrete key
                var SecretKeyString = builder.Configuration.GetValue<string>("SecratKey");
                var SecreteKeyBytes = Encoding.ASCII.GetBytes(SecretKeyString);
                SecurityKey securityKey = new SymmetricSecurityKey(SecreteKeyBytes);
                //--------------------------------------------------------------

                Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = securityKey,
                    //false mean anyone can send and eny one can take
                    ValidateIssuer = false,//take token(backend)//make token
                    ValidateAudience = false//send token(frontend)//use token
                };
            });

            builder.Services.AddHttpContextAccessor();

            //        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddDefaultTokenProviders()
            //.AddEntityFrameworkStores<EducationPlatformContext>();
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddDefaultTokenProviders()
            //.AddEntityFrameworkStores<EducationPlatformContext>();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

            //    Define the security scheme
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        In = ParameterLocation.Header,
            //        Description = "Please enter a valid token",
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.Http,
            //        BearerFormat = "JWT",
            //        Scheme = "Bearer"
            //    });

            //    Apply the security requirement globally
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //        {
            //            {
            //                new OpenApiSecurityScheme
            //                {
            //                    Reference = new OpenApiReference
            //                    {
            //                        Type = ReferenceType.SecurityScheme,
            //                        Id = "Bearer"
            //                    }
            //                },
            //                new string[] { }
            //            }
            //        });
            //});
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                // Define the security scheme
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // Apply the security requirement globally
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });

            builder.Services.AddAutoMapper(map => map.AddProfile(new Examresultmappingprofile()));

            builder.Services.AddAutoMapper(map => map.AddProfile(new LectureMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new PdfFileMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new VedioMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new CourseMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuizResultMappingProfile()));

            builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerResultMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuestionMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new EnrollmentMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new StudentMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new InstructorMappingProfile()));
          builder.Services.AddAutoMapper(map => map.AddProfile(new QuizMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new ExamMappingProfile()));

            //      builder.Services.AddAutoMapper(map => map.AddProfile(new QuizMappingProfile()));


            
           builder.Services.AddScoped<IEnrollmentRepo,EnrollmentRepo>();
            builder.Services.AddScoped<IenrollmentManager, EnrollmentManager>();

            builder.Services.AddScoped<IQuizResultRepo, QuizResultRepo>();
            builder.Services.AddScoped<IQuizResultManager, QuizResultManager>();
            builder.Services.AddScoped<IExamResultRepo, ExamResultRepo>();
            builder.Services.AddScoped<IExamResultmanager, examresultmanager>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<Istudentmanager, Stuentmanager>();
            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
            builder.Services.AddScoped<IInstructorManager, instructorManager>();

            builder.Services.AddScoped<IQuizRepo, QuizRepo>();
           builder.Services.AddScoped<IQuizManager, QuizManager>();
            //builder.Services.AddScoped<IQuizManager, QuizManager>();
            builder.Services.AddScoped<Iexamrepo, examrepo>();
            builder.Services.AddScoped<IExamManager, ExamManager>();




            builder.Services.AddScoped<IAccountManger, AccountManger>();

            builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
            builder.Services.AddScoped<IAnswerManager, AnswerManager>();

            builder.Services.AddScoped<IAnswerResultRepo, AnswerResultRepo>();
            builder.Services.AddScoped<IAnswerResultManager, AnswerResultManager>();

            builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
            builder.Services.AddScoped<IQuestionManager, QuestionManager>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<ILectureRepo, LectureRepo>();
            builder.Services.AddScoped<ILectureManager, LectureManager>();
            builder.Services.AddScoped<IPdfFileRepo, PdfFileRepo>();
            builder.Services.AddScoped<IPdfFileManager, PdfFileManager>();
            builder.Services.AddScoped<IVedioRepo, VedioRepo>();
            builder.Services.AddScoped<IVedioManager, VedioManager>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<ICourseManager, CourseManager>();
            // builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericClass<>) );
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
        }
    }
}
