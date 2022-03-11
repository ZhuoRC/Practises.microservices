docker build -t mymicroservice .

docker rmi $(docker images -f dangling=true -q)

docker run -it --rm -p 3000:80 --name mymicroservicecontainer mymicroservice