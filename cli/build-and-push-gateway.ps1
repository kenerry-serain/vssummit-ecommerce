(Get-ECRLoginCommand -ProfileName ksse -Region us-east-1).Password | docker login --username AWS --password-stdin 968225077300.dkr.ecr.us-east-1.amazonaws.com
cd ..
docker build -f VsSummitEcommerce\VsSummitEcommerce.Gateway\Dockerfile VsSummitEcommerce\. -t 968225077300.dkr.ecr.us-east-1.amazonaws.com/ecommerce/production/gateway-api:latest
docker push 968225077300.dkr.ecr.us-east-1.amazonaws.com/ecommerce/production/gateway-api:latest