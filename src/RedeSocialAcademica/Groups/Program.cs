using Groups.Domain.DomainServices;
using Groups.Domain.Interfaces.ApplicationServices;
using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Interfaces.Repositories.SqlServer;
using Groups.Domain.Models.MongoDBModels.Rooms;
using Groups.Infra.Context;
using Groups.Infra.Repository.MongoDB.RoomsDataPersistence;
using Groups.Infra.Repository.SqlServer;
using Groups.Presentation.ApplicationServices;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GroupsDbContext>(options =>
    options.UseSqlServer(sqlServerConnection));

builder.Services.AddScoped<IGroupServices, GroupServices>();
builder.Services.AddScoped<IUserGroupServices, UserGroupServices>();
builder.Services.AddScoped<IAssignmentServices, AssignmentServices>();
builder.Services.AddScoped<IAnnouncementServices, AnnouncementServices>();
builder.Services.AddScoped<IDoubtServices, DoubtServices>();
builder.Services.AddScoped<IAnswerServices, AnswerServices>();
builder.Services.AddScoped<IConversationServices, ConversationServices>();
builder.Services.AddScoped<IAnswerCommentServices, AnswerCommentServices>();
builder.Services.AddScoped<IArticleServices, ArticleServices>();
builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<ICommentServices, CommentServices>();
builder.Services.AddScoped<IMessageServices, MessageServices>();

builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentSentRepository, AssignmentSentRepository>();
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAssignmentFileRepository, AssignmentFileRepository>();
builder.Services.AddScoped<IDoubtRepository, DoubtRepository>();
builder.Services.AddScoped<IDoubtFileRepository, DoubtFileRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IDoubtVoteRepository, DoubtVoteRepository>();
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IAnswerVoteRepository, AnswerVoteRepository>();
builder.Services.AddScoped<IAnswerCommentRepository, AnswerCommentRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostVoteRepository, PostVoteRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IPostFileRepository, PostFileRepository>();
builder.Services.AddScoped<IConversationUserRepository, ConversationUserRepository>();
builder.Services.AddScoped<IGroupCategoryRepository, GroupCategoryRepository>();

builder.Services.AddScoped<IGroupApplicationServices, GroupApplicationServices>();
builder.Services.AddScoped<IUserGroupApplicationServices, UserGroupApplicationServices>();
builder.Services.AddScoped<IAssignmentApplicationServices, AssignmentApplicationServices>();
builder.Services.AddScoped<IAnnouncementApplicationServices, AnnouncementApplicationServices>();
builder.Services.AddScoped<IDoubtApplicationServices, DoubtApplicationServices>();
builder.Services.AddScoped<IAnswerApplicationServices, AnswerApplicationServices>();
builder.Services.AddScoped<IDoubtVoteApplicationServices, DoubtVoteApplicationServices>();
builder.Services.AddScoped<IConversationApplicationServices, ConversationApplicationServices>();
builder.Services.AddScoped<IAnswerVoteApplicationServices, AnswerVoteApplicationServices>();
builder.Services.AddScoped<IAnswerCommentApplicationServices, AnswerCommentApplicationServices>();
builder.Services.AddScoped<IMessageApplicationServices, MessageApplicationServices>();
builder.Services.AddScoped<IArticleApplicationServices, ArticleApplicationServices>();
builder.Services.AddScoped<IPostApplicationServices, PostApplicationServices>();
builder.Services.AddScoped<IPostVoteApplicationServices, PostVoteApplicationServices>();
builder.Services.AddScoped<ICommentApplicationServices, CommentApplicationServices>();
builder.Services.AddScoped<IAssignmentSentApplicationServices, AssignmentSentApplicationServices>();
builder.Services.AddScoped<IConversationUserApplicationServices, ConversationUserApplicationServices>();

builder.Services.AddScoped<RoomsRepository>();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("C:\\AspNet-DataProtection-keys"))
    .SetDefaultKeyLifetime(TimeSpan.FromDays(90))
    .SetApplicationName("CadastroUsuario");

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", o =>
    {
        o.Cookie.Name = "Token";
        o.ExpireTimeSpan = TimeSpan.FromDays(90);
        o.Cookie.HttpOnly = true;
        o.SlidingExpiration = true;
        o.Cookie.Domain = "localhost";
        o.Cookie.Path = "/";
        o.Cookie.SameSite = SameSiteMode.None;
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        o.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        o.DataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo("C:\\AspNet-DataProtection-keys"));
    });

builder.Services.AddAuthorization();

BsonClassMap.RegisterClassMap<Room>(rooms =>
{
    rooms.AutoMap();
    rooms.MapIdProperty(r => r.Id)
        .SetIdGenerator(ObjectIdGenerator.Instance);
});

builder.Services.Configure<RoomSettings>(builder.Configuration.GetSection("RoomsDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .WithOrigins("https://localhost:5173", "https://localhost:7000")
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/HelloWorld", () => {
    return Results.Ok("Hello World");
});

app.Run();