using DomainDrivenDesign.Practices.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Practices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),typeof(Entity).Assembly);

                cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzk4MjQzMjAwIiwiaWF0IjoiMTc2Njc4NzA5OSIsImFjY291bnRfaWQiOiIwMTliNWNiNzNjMmE3NGIwODFlZGQzY2I1NmMzYTQzMCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa2RlYmZhajI1cDV3OGUxMnJtYWc0ZGFwIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.g-UExFSz7Q0Xbl6cCCDPHz4vmK_iE6XC5SK9mkNO3-LpPP5FzfytzRnZ57BiagM1Op3d11datHmUkRjW4G-hSlcvVdeDP2iPTx5xNVWJUd4Kj2k24FWs4AZpojHK3hcu10KdZWPO_wzVs3pbVYGBlF9ZaeGdISzKxlkDxfNwFNF1lKgSqlyVwNaYXO9qiR7ZZ_-FbMV9wV9kU6pDElmAaN_CUpr6bh89adWZISdyYO2nvnnjW1z6e40yUmw9VJBCcRvrBsmI_fCnJLBX6l-mYjOg7rbaNQwuvfuFRbYlWaWdPxfDkD_-3qZqeU-QqEphWU2XrbiXSH1DHkAyXcvm7w";
            });
            
            return services;
        }
    }
}
