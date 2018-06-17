FROM microsoft/dotnet
COPY . /app
WORKDIR /app
RUN ["dotnet", "build"]
EXPOSE 61195
RUN chmod +x Scripts/entrypoint.sh
CMD /bin/bash Scripts/entrypoint.sh