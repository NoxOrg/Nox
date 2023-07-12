sleep 2 &&
# Organization vault
curl -v -X POST http://vault:8300/v1/secret/data/org-vault \
    --header "X-Vault-Token: root" \
    --data-binary @- << EOF
    {
    	"data": {
    		"org-only-secret": "This is an organization only secret",
    		"org-sln-secret": "This is a secret that exists in org and sln and this is the organization value",
    		"org-sln-user-secret": "This is a secret that exists in org, sln and user and this is the organization value"    			
    	}	
    }
    EOF


