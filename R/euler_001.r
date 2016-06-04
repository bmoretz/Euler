# If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
# The sum of these multiples is 23.
# Find the sum of all the multiples of 3 or 5 below 1000.

euler1 <- function ( x )
{
  i <- 0
  
  for( n in x )
  {
    if( ( n %% 3 == 0 ) || ( n %% 5 == 0 ) )
      i <- i + n
  }
  
  return( i )
}

euler1(c(1:999))