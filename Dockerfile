FROM mono:4.7
RUN apt-get update -y && apt-get install mono-complete -y

RUN mkdir -p app 
ADD . /app
WORKDIR /app

RUN xbuild HipchatCS.sln

