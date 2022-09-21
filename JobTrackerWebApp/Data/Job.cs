using JobTrackerWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerWebApp.Data
{
    public class Job
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
    }


public static class JobEndpoints
{
	public static void MapJobEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Job", async (ApplicationDbContext db) =>
        {
            return await db.Job.ToListAsync();
        })
        .WithName("GetAllJobs")
        .Produces<List<Job>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Job/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.Job.FindAsync(Id)
                is Job model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetJobById")
        .Produces<Job>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Job/{id}", async (int Id, Job job, ApplicationDbContext db) =>
        {
            var foundModel = await db.Job.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateJob")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Job/", async (Job job, ApplicationDbContext db) =>
        {
            db.Job.Add(job);
            await db.SaveChangesAsync();
            return Results.Created($"/Jobs/{job.Id}", job);
        })
        .WithName("CreateJob")
        .Produces<Job>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Job/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await db.Job.FindAsync(Id) is Job job)
            {
                db.Job.Remove(job);
                await db.SaveChangesAsync();
                return Results.Ok(job);
            }

            return Results.NotFound();
        })
        .WithName("DeleteJob")
        .Produces<Job>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
