FROM microsoft/dotnet:2.1-sdk as builder

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# Optimize for Docker builder caching by adding projects first.

RUN mkdir -p /root/src/function
WORKDIR /root/src/function
COPY ./function/*.csproj  ./

WORKDIR /root/src/

COPY .  .

RUN dotnet add ./root.csproj reference **/*.csproj 

RUN dotnet restore ./root.csproj

RUN dotnet publish -c release -o published

FROM microsoft/dotnet:2.1-runtime

RUN echo "Pulling watchdog binary from Github." \
    && curl -sSL https://github.com/openfaas/faas/releases/download/0.8.10/fwatchdog > /usr/bin/fwatchdog \
    && chmod +x /usr/bin/fwatchdog

WORKDIR /home/app/
COPY --from=builder /root/src/published .

RUN chown app:app -R /home/app

USER app

ENV fprocess="dotnet ./root.dll"
EXPOSE 8080

HEALTHCHECK --interval=1s CMD [ -e /tmp/.lock ] || exit 1

CMD ["fwatchdog"]
